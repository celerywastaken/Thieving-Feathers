using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("SCORE")]
    public TextMeshProUGUI scoreText;
    private int score;
    //prevents the Score from going below 0
    public int Score
    {get{return score;} set{if (value < 0) { score = 0; }}}

    [Header("Highscore")]
    private int highscore;
    [SerializeField] TextMeshProUGUI highScoreText;
    public TextMeshProUGUI yourScoreText;


    [Header("Timer")]
    public TextMeshProUGUI timerText;
    private float timeRemaining = 60;
    private bool timerIsRunning = false;

    [SerializeField] private SpawnManager spawnManger;
    [SerializeField] private GameObject endOfTimerPanel;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button homeBtn;

    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource timerOverMusic;
   

    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore",0);
        spawnManger = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        timerIsRunning = true;
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

    }

    private void Timer()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timerText.text = "Time:" + timeRemaining.ToString("00");
            }

            else
            {
                Debug.Log("Time has run out!");
                endOfTimerPanel.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
                spawnManger.isGameActive = false;
                yourScoreText.text = "Score:" + score;
                bgMusic.Stop();
                timerOverMusic.Play();

                //set highscore
                if (highscore < score)
                {
                    PlayerPrefs.SetInt("highscore", score);
                    highscore = score;
                }
                highScoreText.text = "Highscore:" + highscore;
            }
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        //set normal score
        score += scoreToAdd;
        scoreText.text = "Score:" + score;

       
        
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("This Button is working");

    }

    public void HomeScreen()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
