using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    private bool levelEndInitialized = false;

    public float levelTime;
    public GameObject LevelEndParticle;

    private float startDelay;
    private int sceneIndex;

    public UnityEvent OnLevelEnd;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        startDelay = Time.time;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Target.targetcount==0 && !levelEndInitialized)
        {
            levelEndInitialized = true;
            levelTime = Time.time-startDelay;
            LevelEndParticle.SetActive(true);
            Highscore.UpdateHighscore(sceneIndex, levelTime);
            OnLevelEnd.Invoke();
        } else if (!levelEndInitialized)
        {
            levelTime = Time.time-startDelay;
        }
    }
    public void Restartlevel()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
