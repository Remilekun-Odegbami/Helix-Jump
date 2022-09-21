using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    // method that is called when the ball hits the ground or a collider
    private void OnCollisionEnter(Collision collision)
    {
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        if (materialName == "Safe (Instance)")
        {
            // The ball hits the safe area
        }
        else if (materialName == "Unsafe (Instance)")
        {
            GameManager.gameOver = true;

        }
        else if (materialName == "LastRing (Instance)")
        {
            GameManager.levelCompleted = true; ;
        }
    }
}
