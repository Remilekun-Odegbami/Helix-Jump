using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Xml;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public static bool isLevelCompleted;
    public static bool isGameStarted;
    public static bool isTimeUp;
    public static bool mute = false;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;
    public GameObject timeUpPanel;

    public static int currentLevelIndex;
    public static int numOfPassedRings;
    public static int score = 0;

    public Slider gameProgressSlider;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    // called before the start method
    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);

    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        numOfPassedRings = 0;
        isGameStarted = false;
        isGameOver = false;
        isLevelCompleted = false;
        isTimeUp = false;
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0); // player prefs is used to store key value pairs

    }

    // Update is called once per frame
    void Update()
    {
        // update UI slider text
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numOfPassedRings * 100 / FindObjectOfType<HelixManager>().numOfRings;

        scoreText.text = "Score: " + score.ToString();

        gameProgressSlider.value = progress;

        // For PC
        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            // if the player is pointing to a UI element on PC
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        }
        //For Mobile
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        //{
        //    // if the player is pointing to a UI element on Mobile
        //    if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        //    {
        //        return;
        //    }
        //    isGameStarted = true;
        //    gamePlayPanel.SetActive(true);
        //    startMenuPanel.SetActive(false);
        //}

        if (isGameOver)
        {
            GameOver();
        }

        if (isLevelCompleted)
        {
            LevelCompleted();
        }

        if (isTimeUp)
        {
            TimeUp();
        }

    }

    void GameOver()
    {
        // stop the game by stopping the time
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);

        //reload the level 
        if (Input.GetButtonDown("Fire1"))
        {
            // check if there is a new highscore 
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                // set player score to high score
                PlayerPrefs.SetInt("HighScore", score);
            }
            // reset the score on game over
            score = 0;
            SceneManager.LoadScene("Level");
        }
    }

    void LevelCompleted()
    {
        Time.timeScale = 0;
        levelCompletedPanel.SetActive(true);

        //reload the level 
        if (Input.GetButtonDown("Fire1"))
        {
            // change current level text to current level
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex + 1);
            // load next level
            SceneManager.LoadScene("Level");

        }
    }
    void TimeUp()
    {
        // stop the game by stopping the time
        Time.timeScale = 0;
        timeUpPanel.SetActive(true);

        //reload the level 
        if (Input.GetButtonDown("Fire1"))
        {
            //// check if there is a new highscore 
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                // set player score to high score
                PlayerPrefs.SetInt("HighScore", score);
            }
            // reset the score on game over
            score = 0;
            SceneManager.LoadScene("Level");
        }
    }
}