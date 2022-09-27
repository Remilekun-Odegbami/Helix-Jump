using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class HelixManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public float ySpawn = 0;
    public float ringDistance = 5;

    public int numOfRings;

    // Start is called before the first frame update
    void Start()
    {
        numOfRings = GameManager.currentLevelIndex + 5;
        // spawn helix rings
        for (int i = 0; i < numOfRings; i++)
        {
            if (i == 0) // spawn only the rings with all green at the beginning everytime
            {
                SpawnRing(0);
            }
            else
            {
                SpawnRing(Random.Range(1, helixRings.Length - 1)); // spawn the rings at random 
            }
        }

        // spawn the last ring (or element) at the end of the game
        SpawnRing(helixRings.Length - 1);
    }


    // function to spawn the rings on the y axis
    public void SpawnRing(int ringIndex)
    {
        GameObject gameRings = Instantiate(helixRings[ringIndex], transform.up * ySpawn, Quaternion.identity);
        // this helps to make the helix rings children of the helix manager
        gameRings.transform.parent = transform;
        ySpawn -= ringDistance; // distance between the helix rings
    }
}



