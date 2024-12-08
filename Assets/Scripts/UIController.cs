using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText,comepleteTimeText;
    [SerializeField] private TMP_Text targetCounterText;
    [SerializeField] private GameObject levelEndPanel;
    [SerializeField] private Image aim;


    private float targetsAtStart;


    private void Start()
    {
        targetsAtStart = Target.targetcount;
        levelEndPanel.SetActive(false);
        LevelController.Instance.OnLevelEnd.AddListener(EndLevel);
    }

    void Update()
    {
        targetCounterText.text =targetsAtStart-Target.targetcount + "/" + targetsAtStart;
        timerText.text =Highscore.GetLevelTimeAsString(LevelController.Instance.levelTime);
    }
    private void EndLevel()
    {
        levelEndPanel.SetActive(true);
        comepleteTimeText.text = Highscore.GetLevelTimeAsString(LevelController.Instance.levelTime);
        aim.enabled = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
