using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WinGame : MonoBehaviour
{
    public void Start()
    {
        pointsText.text = score.ToString();
    }

    public void PlayGame()
    {
        if (GameManager.Level == "Easy")
        {
            GameManager.Level = "Medium";
        }
       else if (GameManager.Level == "Medium")
        {
            GameManager.Level = "Hard";
        }
        else
            GameManager.Level = "Easy";
        SceneManager.LoadScene("GameLevels");
          
       
    }
    public void PlayMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

public   Text pointsText;
    public static string score = "0";
    //public void Setup (int score)
    //  {
    //      gameObject.SetActive (true);
    //      pointsText.text = score.ToString() + "POINTS";
    //  }
}
