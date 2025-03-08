using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _score;

    void Start()
    {
        _score = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log($"At start {_score} enemies total."); // $ allows you to break the string with {}
    }

    public void ReduceScore()
    {
        _score--;
        Debug.Log($"{_score} enemies remaining");
        if (_score <= 0)
        {
            GameEventDispatcher.TriggerEnemiesAllDefeated();
        }
    }

    private void OnEnable()
    {
        GameEventDispatcher.EnemyDefeated += ReduceScore;
    }

    private void OnDisable()
    {
        GameEventDispatcher.EnemyDefeated -= ReduceScore;
    }
}
