using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter = 0;
    // Start is called before the first frame update
    void Start()
    {
        // disable all characters
        foreach(GameObject character in characters)
        {
            character.SetActive(false);
        }
        // enable only selected character
        characters[selectedCharacter].SetActive(true);
    }

// change selected character to be the player
    public void ChangeCharacter(int newCharacter)
    {
        characters[selectedCharacter].SetActive(false); // disable default character
        characters[newCharacter].SetActive(true); // enable selected character
        selectedCharacter = newCharacter; // make selected character become the player
    }
}
