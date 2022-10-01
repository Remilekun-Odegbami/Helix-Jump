using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 150; // 20 for mobile, 150 for pc

    // Start is called before the first frame update
    void Start()
    {
        // hide the cursor on the screen
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // check if game is started before allowing users to rotate the cylinder
        if (!GameManager.isGameStarted) { return; }

        //Rotate cylinder for PC
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxisRaw("Mouse X"); // get the mouse input
            transform.Rotate(0, -mouseX * rotationSpeed * Time.deltaTime, 0); // make the cylinder rotate on mouse direction
        }

        //Rotate cylinder For Mobile
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    float xDelta = Input.GetTouch(0).deltaPosition.x;
        //    transform.Rotate(0, -xDelta * rotationSpeed * Time.deltaTime, 0);
        //}
    }
}
