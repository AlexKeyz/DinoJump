using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using YG;

public class ScoreUI : MonoBehaviour
{
    private Text _field;
    //private Text _recordField;
    public Text RecordScoreText;
    public static int _score = 0;
    public static int _recordScore = 0;

    private void Awake()
    {
        _field = GetComponent<Text>();
        //_recordField = GetComponent<Text>();
    }
    void Start()
    {
        YandexGame.NewLeaderboardScores("LiderBordClicker", _recordScore);
        _recordScore = PlayerPrefs.GetInt("RecordScore", 0);
        _field.text = _score.ToString();
        //_recordField.text = _recordScore.ToString();
        RecordScoreText.text = _recordScore + "";
    }

    private void Update()
    {
        RecordScoreText.text = _recordScore + "";
    }
    public void IncreaseScor()
    {
        if (PlayerController._PlatformCheck == true)
        {
                    _score += 1;
                    _field.text = _score.ToString();
                    if (_score > _recordScore)
                    {
                        _recordScore = _score;
                    }
                    RecordScoreText.text = _recordScore + "";
                    //_recordField.text = _recordScore.ToString();
                    PlayerPrefs.SetInt("RecordScore", _recordScore);
                    YandexGame.savesData.money = _recordScore;
        }
        
        
    }
}
