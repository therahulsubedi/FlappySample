using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Use this for initialization
    public int score;
    public Text scoreText;
    public int highscore;
    public Text HighscoreText;
    public static ScoreManager MyObject;

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        HighscoreText.text = "Best " + highscore.ToString();

        MyObject = this;
    }


    public void addScore(int s)
    {
        if (score > 1)
        {
            CloneMaker.MyObject.ReuseMe();

        }
        
            //reuse from queue
            score++;
            scoreText.text = score.ToString();
            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("highscore", highscore);
                HighscoreText.text = "Best " + highscore.ToString();
            }
        
    }
}