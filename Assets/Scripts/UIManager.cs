using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("SCORE")]
    public TextMeshProUGUI scoreText;    // Reference to the score text UI element
    private int score;                  // Current score value

    public int Score    //prevents the Score from going below 0
    { get{return score;} set{if (value < 0) { score = 0; }}}

    [Header("Highscore")]
    private int highscore;                                   // Current highscore value
    [SerializeField] TextMeshProUGUI highScoreText;         // Reference to the highscore text UI element
    public TextMeshProUGUI yourScoreText;                  // Reference to the "Your Score" text UI element


    [Header("Timer")]
    public TextMeshProUGUI timerText;        // Reference to the timer text UI element
    private float timeRemaining = 60;       // Initial time remaining
    private bool timerIsRunning = false;   // Indicates if the timer is running

    [SerializeField] private SpawnManager spawnManger;              // Indicates if the timer is running
    [SerializeField] private GameObject endOfTimerPanel;           // Reference to the end of timer panel GameObject
    [SerializeField] private Button retryBtn;                     // Reference to the retry button
    [SerializeField] private Button homeBtn;                     // Reference to the home button

    [SerializeField] private AudioSource bgMusic;              // Reference to the background music AudioSource
    [SerializeField] private AudioSource timerOverMusic;      // Reference to the timer over music AudioSource


    void Start()
    {
        // Get the highscore from PlayerPrefs, default to 0 if not found
        highscore = PlayerPrefs.GetInt("highscore",0);  

        spawnManger = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        timerIsRunning = true;
        score = 0;

        // Update the score UI
        UpdateScore(0);
    }

    void Update()
    {
        // Update the timer
        Timer();    
    }

    private void Timer()    // Update the timer and handle end of timer conditions
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
                // Display end of timer panel and handle end of game conditions
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
    public void UpdateScore(int scoreToAdd) // Update the score and the score UI
    {
        //set normal score
        score += scoreToAdd;
        scoreText.text = "Score:" + score;

    }

    public void ReloadGame()    // Reload the game scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomeScreen()    // Load the home screen scene
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
