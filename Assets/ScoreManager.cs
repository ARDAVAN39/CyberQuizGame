using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
   // public Text scoreText { get { return scoreText; } }
   //public Text timerText { get { return timerText; } }
    public static ScoreManager instance;
    public Text scoreText;
    public Text HighscoreText;
   // public float scoreCount;
    //public float highscoreCount;
    int score = 0;
    int Highscore = 0;
    private void Awake()
   {
       instance = this;
    }
    //private GameStatus gameStatus=GameStatus.Next;
    //public GameStatus GameStatus { get { return gameStatus; } }
    // Start is called before the first frame update
    public void StartGame()
    {   

        //gameStatus=GameStatus.Playing;
        Highscore = PlayerPrefs.GetInt("Highscore",0);
        scoreText.text = score.ToString() + " POINTS ";
        HighscoreText.text = "HIGHSCORE: " + Highscore.ToString();
    }
   // public void AddPoint()
//{
   //     score += 1;
   //     scoreText.text = score.ToString() + "POINTS";
   //     if (score > Highscore)
    //    PlayerPrefs.SetInt("HighScore",score);
  //  }
  //  [System.Serializable]
  //  public enum GameStatus
  //  {
    //    Next,
      //  Playing
  //  }

    // Update is called once per frame
    //void Update()
   // {
     //   scoreText.text = "score : " + scoreCount;
      //  HighscoreText.text = "HighScore : " + highscoreCount;
        //scoreText.text = "50";
   // }
   
}
