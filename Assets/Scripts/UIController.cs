using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text targetCounterText;

    private float targetsAtStart;

    private void Start()
    {
        targetsAtStart = Target.targetcount;
    }

    void Update()
    {
        targetCounterText.text =targetsAtStart-Target.targetcount + "/" + targetsAtStart;
        string timeText= Time.time.ToString("0.00");
        if (Time.time<10)
        {
            timerText.text ="0"+ timeText.Replace(",", ":");
        } else
        {
            timerText.text =timeText.Replace(",", ":");

        }
    }
}
