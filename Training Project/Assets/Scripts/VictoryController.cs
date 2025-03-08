using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(ParticleSystem))]
public class VictoryController : MonoBehaviour
{
    public TextMeshProUGUI text;

    public float waitTime = 3f;

    private ParticleSystem _particles;
    void Awake()
    {
        _particles = GetComponent<ParticleSystem>();
    }

    void OnEnable()
    {
        GameEventDispatcher.EnemiesAllDefeated += Celebrate;
    }

    void OnDisable()
    {
        GameEventDispatcher.EnemiesAllDefeated -= Celebrate;
    }

    private void Celebrate()
    {
        _particles.Play();

        //text = GameObject.Find("Canvas/VictoryText").GetComponent<TextMeshProUGUI>();
        //text.gameObject.SetActive(true);

        StartCoroutine(WaitAndReset());
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
