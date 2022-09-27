using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public static float timeLeft = 40.0f;
    public TextMeshProUGUI timeText;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameStarted)
        {
            timeLeft -= Time.deltaTime;
            timeText.text = "Time: " + (timeLeft).ToString("0");

            if (timeLeft < 0) // if the time is 0
            {
                GameManager.isTimeUp = true;
                Debug.Log("Time Up!");
                timeLeft = 40.0f;
            }
        }
    }
}
