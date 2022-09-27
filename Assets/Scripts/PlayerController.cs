using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public ParticleSystem explosion;
    public float bounceForce = 6;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // method that is called when the ball hits the ground or a collider
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("Bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        if (materialName == "Safe (Instance)")
        {
            // The ball hits the safe area
            explosion.Stop();
        }
        else if (materialName == "Unsafe (Instance)")
        {
            GameManager.isGameOver = true;
            audioManager.Play("Game Over");

        }
        else if (materialName == "Last Ring (Instance)" && !GameManager.isLevelCompleted)
        {
            explosion.Play();
            GameManager.isLevelCompleted = true;
            audioManager.Play("Level Completed");
        }
    }
}
