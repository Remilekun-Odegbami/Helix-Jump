using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI muteText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            muteText.text = "/";
        } else
        {
            muteText.text = "";
        }
    }

    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            muteText.text = "";
        } else
        {
            GameManager.mute = true;
            muteText.text = "/";
        }
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
