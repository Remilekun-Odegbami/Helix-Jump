using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    public float smoothSpeed = 0.04f;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; // main camera position - player position
    }

    void LateUpdate()
    {
        // Vector3.Lerp helps the camera follow the player smoothly 
        Vector3 newPosition = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);

        // set main camera position to the player position
        transform.position = newPosition;
    }
}
