using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour
{

    public void PlayGame()
    {
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

public Text pointsText;
  public void Setup (int score)
    {
        gameObject.SetActive (true);
        pointsText.text = score.ToString() + "POINTS";
    }
}
