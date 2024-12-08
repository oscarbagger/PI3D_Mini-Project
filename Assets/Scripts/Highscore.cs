using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Highscore
{
    public static float level1Highscore=99.99f;
    public static float level2Highscore=99.99f;
    public static float level3Highscore=99.99f;

    public static void LoadSavedScores()
    {
        if ( PlayerPrefs.HasKey("level1"))
        {
            level1Highscore = PlayerPrefs.GetFloat("level1");
        }
        if (PlayerPrefs.HasKey("level2"))
        {
            level2Highscore = PlayerPrefs.GetFloat("level2");
        }
        if (PlayerPrefs.HasKey("level3"))
        {
            level3Highscore = PlayerPrefs.GetFloat("level3");
        }
    } 

    public static void UpdateHighscore(int index, float time)
    {
        switch(index)
        {
            case 1:
                if (time<level1Highscore)
                {
                    level1Highscore = time;
                    PlayerPrefs.SetFloat("level1", time);
                }
                break;
            case 2:
                if (time < level2Highscore)
                {
                    level2Highscore = time;
                    PlayerPrefs.SetFloat("level2", time);
                }
                break;
            case 3:
                if (time < level1Highscore)
                {
                    level2Highscore = time;
                    PlayerPrefs.SetFloat("level3", time);
                }
                break;
            default:
                break;
        }
    }
    public static string GetLevelTimeAsString(float value)
    {
        string txt = value.ToString("0.00");
        if (value < 10)
        {
            txt = "0" + txt.Replace(",", ":");
        }
        else
        {
            txt = txt.Replace(",", ":");
        }
        return txt;
    }
}
