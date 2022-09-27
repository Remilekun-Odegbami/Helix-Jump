using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject gamePausedPanel;

    // Update is called once per frame
    void Update()
    {
        // For Mobile
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }


        void Resume()
        {
            // resume game
            gamePausedPanel.SetActive(false);
            Time.timeScale = 1f;
            isGamePaused = false;
        }

        void Pause()
        {
            // pause game
            gamePausedPanel.SetActive(true);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
    }
}
