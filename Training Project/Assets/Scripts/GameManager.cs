using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Starting = 1,
    Playing = 10,
    Paused = 15,
    FailScreen = 20,
    VictoryDance = 25
}


public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;
    public GameState State { get; private set; }

    private GameState _previousState = GameState.Starting;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(GameState.Starting);
    }

    public void ChangeState(GameState newState)
    {
        //Give a chance for objects that care to do something
        //before GameManager does things in this state

        OnBeforeStateChanged?.Invoke(newState);

        _previousState = State; // remember for un-pausing

        State = newState;
        Debug.Log("Changed Game State to    :" + newState);

        //if we were just paused, handle un-pausing
        if (_previousState == GameState.Paused)
        {
            Time.timeScale = 1;
        }
     
        switch (newState)
        {
            case GameState.Starting:
                StartCoroutine(HandleStarting());
                break;
            case GameState.Playing:
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                break;
            case GameState.FailScreen:
                break;
            case GameState.VictoryDance:
                break;
            default:
                Debug.Log("GameState not handled: " + nameof(newState));
                break;
        }
        OnAfterStateChanged?.Invoke(newState);
    }

    private IEnumerator HandleStarting()
    {
        yield return new WaitForSeconds(2);
        ChangeState(GameState.Playing);
    }

    //Call to pause or un-pause based on current state
    public void TogglePause()
    {
        //ChangeState toggles between Paused and previous state
        if (State == GameState.Paused)
            ChangeState(_previousState);
        else
            ChangeState(GameState.Paused);
    }

}