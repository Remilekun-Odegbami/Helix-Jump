using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;

    public static int currentLevelIndex;
    public static int numOfPassedRings;

    public Slider gameProgressSlider;

    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

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
        gameOver = false;
        levelCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        // update UI slider text
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex + 1).ToString();

        int progress = numOfPassedRings * 100 / FindObjectOfType<HelixManager>().numOfRings;

        gameProgressSlider.value = progress;


        if (gameOver)
        {
            // stop the game by stopping the time
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            //reload the level 
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level");
            }
        }

        if (levelCompleted)
        {
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
    }
}
