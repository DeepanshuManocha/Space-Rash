using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public Text testScore, testScore1;
    public Text HighScore;
    int score;


    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score=value;
            UpdateScoreTest();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        HighScore.text=PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    void UpdateScoreTest()
    {
        string scoreStr=string.Format("{0:0}",score);
        testScore.text=scoreStr;
        testScore1.text=scoreStr;
        if(Score>PlayerPrefs.GetInt("HighScore",0))
            {
                PlayerPrefs.SetInt("HighScore",Score);
                HighScore.text=Score.ToString();
            }
    }
}
