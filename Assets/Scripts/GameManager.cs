using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static ScoreManager instance;
    //public static int MaxHealth = 3;
    //public static int PlayerHealth = 3;
    //public GameOverScreen GameOverScreen;
    public Text scoreText;
    public Text WrongAnswerText;
    public Text HighscoreText;
    public float scoreCount;
    public float highscoreCount;
    [SerializeField]
    private int WrongAnswerCount = 0;
    [SerializeField]
    private int TrueAnswerCount = 0;
    int score = 0;
    int Highscore = 0;





    private IEnumerator IE_StartTimer = null;
    private Color timerDefaultColor;

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    public Question currentQuestion;
    [SerializeField]
    public Text factText;
    [SerializeField]
    public Text TrueAnswerText;
    [SerializeField]
    private Text FalseAnswerText;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    List<AudioSource> sounds = new List<AudioSource>();
    [SerializeField]
    public Text timerText;
    [SerializeField] private List<Image> lifeImageList;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] Animator timerAnimator = null;
    //[SerializeField] TextMeshProUGUI timerText = null;
    [SerializeField] Color timerHalfWayOutColor = Color.yellow;
    [SerializeField] Color timerAlmostOutColor = Color.red;
    [SerializeField]
    public float timeBetweenQuestions = 1f;
    //ScoreManager x = new ScoreManager();
    //public Text scoreText { get { return scoreText; } }
    public static string Level = "Easy";
    public Text LevelText;
    void Start()
    {
       
        WrongAnswerText.text = "Wrong Answer : " + WrongAnswerCount.ToString();
        // PlayerHealth = MaxHealth;
        //transform.gameObject.GetComponentInChildren<Text>().text= PlayerHealth.ToString();
        //    timerDefaultColor = timerText.color;

     //   if (unansweredQuestions == null || unansweredQuestions.Count == 0 )
      //  {
            
            unansweredQuestions = questions.ToList<Question>().FindAll(c=>c.Level==Level);

      //  }
        LevelText.text= Level;
        setCurrentQuestion();

        UpdateTimer(true,currentQuestion.Time);
    }
   
    
    void setCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];
        factText.text = currentQuestion.fact;
        if (currentQuestion.isTrue)
        {
            TrueAnswerText.text = "CORRECT";
            FalseAnswerText.text = "WRONG";

        }
        else
        {
            TrueAnswerText.text = "WRONG";
            FalseAnswerText.text = "CORRECT";

        }
       
    }
    void UpdateTimer(bool state,float timeLeft)
    {
        switch (state)
        {
            case true:
                IE_StartTimer = StartTimer(timeLeft);
                StartCoroutine(IE_StartTimer);
                break;
            case false:
                if (IE_StartTimer != null)
                {
                    StopCoroutine(IE_StartTimer);

                }


                break;
        }
    }
    IEnumerator StartTimer(float timeLeft)
    {
        //   var totalTime = questions[currentQuestion].Timer;
        var totalTime = currentQuestion.Time;
        //      var timeLeft = TimeLeft;
        // timerText.color = timerDefaultColor;
        timerText.color = Color.white;
        while (timeLeft > 0)
        {
            timeLeft--;
           // if (timeLeft == 0)
           // {
           //     TransitionToNextQuestion();
           //     break;
           // }
               
            if (timeLeft < totalTime / 2 )
                //&& timeLeft < totalTime / 4)
            {
                timerText.color = timerHalfWayOutColor;
            }

            if (timeLeft < totalTime / 4)
            {
                timerText.color = timerAlmostOutColor;
            }


            timerText.text = timeLeft.ToString();
            yield return new WaitForSeconds(1.0f);
        }
        
          //  TransitionToNextQuestion();
    }
    IEnumerator TransitionToNextQuestion()
    {
        if (unansweredQuestions.Count > 1)
        {


            UpdateTimer(false, 60);
            unansweredQuestions.Remove(currentQuestion);
            yield return new WaitForSeconds(timeBetweenQuestions);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


            setCurrentQuestion();
            UpdateTimer(true, currentQuestion.Time);
        }
        else
        {
           
            WinGame.score = score.ToString();
            SceneManager.LoadScene("YouWin");
        }
    }



    public void UserSelectTrue()
    {
        animator.SetTrigger("True");
        if (currentQuestion.isTrue)
        {


            Debug.Log("CORRECT");
            sounds[0].Play();
            AddPoint(currentQuestion.Score);
            TrueAnswerCount++;

        }
        else
        {
            Debug.Log("WRONG");
            sounds[1].Play();
            WrongAnswerCount += 1;
            WrongAnswerText.text = "Wrong Answer : " + WrongAnswerCount.ToString();
        }
        if (WrongAnswerCount == 3)
            SceneManager.LoadScene("GameOverScreen");
        //if (TrueAnswerCount == 3)
        //    SceneManager.LoadScene("YouWin");
        StartCoroutine(TransitionToNextQuestion());
      
         
        //  animator.ResetTrigger(0);
        //  animator.ResetTrigger(1);
        // animator.ResetTrigger(2);
        // ResetAllTrigger();
    }
    public void UserSelectFalse()
    {
        animator.SetTrigger("False");
        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT");
            sounds[0].Play();
            AddPoint(currentQuestion.Score);
            TrueAnswerCount++;
        }
        else
        {
            Debug.Log("WRONG");
            sounds[1].Play();
            WrongAnswerCount += 1;
            WrongAnswerText.text = "Wrong Answer : " + WrongAnswerCount.ToString();
        }
        if (WrongAnswerCount == 3)
            SceneManager.LoadScene("GameOverScreen");
        //if (TrueAnswerCount == 3)
        //    SceneManager.LoadScene("YouWin");
        StartCoroutine(TransitionToNextQuestion());
        //animator.ResetTrigger(0);
        //animator.ResetTrigger(1);
        //animator.ResetTrigger(2);
        //ResetAllTrigger();
    }
    public void AddPoint(int Score)
    {
        score += Score;
        scoreText.text = score.ToString() + "POINTS";
        if (score > Highscore)
         //   PlayerPrefs.SetInt("HighScore", score);
         Highscore = score;
        HighscoreText.text=" HighScore : " + Highscore.ToString();
         
        
    }
    public void GameOverScreen()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}
