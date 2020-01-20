using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    //void Update()
    //{


    //basic movement
    /*float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    Vector3 direction = new Vector3(horizontal, 0, vertical);
    gameObject.transform.Translate(direction.normalized * Time.deltaTime * speed);*/

    //rigid body 3d
    /*if(Input.GetAxisRaw("Horizontal") != 0) {
        GetComponent<Rigidbody>().angularVelocity = Vector3.right * Input.GetAxisRaw("Horizontal") * speed;

    } else if (Input.GetAxisRaw("Vertical") != 0)
    {
        GetComponent<Rigidbody>().angularVelocity = Vector3.forward * -Input.GetAxisRaw("Vertical") * speed;
    }*/

    //rotate test
    //gameObject.transform.Rotate(direction, Time.deltaTime * speed * 30);
    //}

    public float rotationPeriod = 0.3f;     // Time for the next position
    public float sideLength = 1f;           // Length of Cube

    bool isRotate = false;                  // Is Cube rotating now?
    float directionX = 0;                   // Direction for rotation
    float directionZ = 0;                   // Direction for rotation

    Vector3 startPos;                       // Position before rotation
    float rotationTime = 0;                 // past time for rotation
    float radius;                           // Radius of the center of cube
    Quaternion fromRotation;                // Quaternion before rotation
    Quaternion toRotation;                  // Quaternion after rotation

    // Use this for initialization
    void Start()
    {

        // Radius of the center of cube
        radius = sideLength * Mathf.Sqrt(2f) / 2f;

    }

    // Update is called once per frame
    void Update()
    {

        float x = 0;
        float y = 0;

        // key input
        x = Input.GetAxisRaw("Horizontal");
        if (x == 0)
        {
            y = Input.GetAxisRaw("Vertical");
        }


        // Key input AND cube is not rotating, rotate cube.
        if ((x != 0 || y != 0) && !isRotate)
        {
            directionX = y;                                                             // x direction
            directionZ = x;                                                             // y direction
            startPos = transform.position;                                              // start position
            fromRotation = transform.rotation;                                          // transform position
            transform.Rotate(directionZ * 90, 0, directionX * 90, Space.World);     // rotate inside world
            toRotation = transform.rotation;                                            // amount rotation
            transform.rotation = fromRotation;                                          // Cube delta Rotation
            rotationTime = 0;                                                           // time start
            isRotate = true;                                                            // rotation bool
        }
    }

    void FixedUpdate()
    {

        if (isRotate)
        {

            rotationTime += Time.fixedDeltaTime;                                    // increment time
            float ratio = Mathf.Lerp(0, 1, rotationTime / rotationPeriod);          // get radios

            // Move
            float thetaRad = Mathf.Lerp(0, Mathf.PI / 2f, ratio);                   // delta radios
            float distanceX = -directionX * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));      // Y delta
            float distanceY = radius * (Mathf.Sin(45f * Mathf.Deg2Rad + thetaRad) - Mathf.Sin(45f * Mathf.Deg2Rad));                    // Y delta
            float distanceZ = directionZ * radius * (Mathf.Cos(45f * Mathf.Deg2Rad) - Mathf.Cos(45f * Mathf.Deg2Rad + thetaRad));       // Z delta
            transform.position = new Vector3(startPos.x + distanceX, startPos.y + distanceY, startPos.z + distanceZ);                   // update direction

            // Rotate
            transform.rotation = Quaternion.Lerp(fromRotation, toRotation, ratio);      // Quaternion.Lerp

            // initialize parameters
            if (ratio == 1)
            {
                isRotate = false;
                directionX = 0;
                directionZ = 0;
                rotationTime = 0;
            }
        }
    }

}
