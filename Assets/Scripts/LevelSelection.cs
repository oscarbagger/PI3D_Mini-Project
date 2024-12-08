using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private TMP_Text level1Time, level2Time, level3Time;

    private void Start()
    {
        Highscore.LoadSavedScores();
        SetupLevelSelectUI();
    }

    private void SetupLevelSelectUI()
    {
        level1Time.text = Highscore.GetLevelTimeAsString(Highscore.level1Highscore);
        level2Time.text = Highscore.GetLevelTimeAsString(Highscore.level2Highscore);
        level3Time.text = Highscore.GetLevelTimeAsString(Highscore.level3Highscore);

    }

    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
}
