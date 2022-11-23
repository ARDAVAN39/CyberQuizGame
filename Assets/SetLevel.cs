using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetLevel : MonoBehaviour
{
    public void ActiveLevelEasy()
    {
        GameManager.Level = "Easy";
        SceneManager.LoadScene("GameLevels");
    }
    public void ActiveLevelMedium()
    {
        GameManager.Level = "Medium";
        SceneManager.LoadScene("GameLevels");
    }
    public void ActiveLevelHard()
    {
        GameManager.Level = "Hard";
        SceneManager.LoadScene("GameLevels");
    }

}
