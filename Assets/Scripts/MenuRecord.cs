using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class MenuRecord : MonoBehaviour
{
    public Text RecordScoreText;
    
    void Start()
    {
        YandexGame.NewLeaderboardScores("LiderBordClicker", ScoreUI._recordScore);
        ScoreUI._recordScore = PlayerPrefs.GetInt("RecordScore", 0);
    }

    
    void Update()
    {
        RecordScoreText.text = ScoreUI._recordScore + "";
    }
}
