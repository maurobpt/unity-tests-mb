using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrid : MonoBehaviour
{
    //object follow another
    /*public GameObject target,structure;
    private Vector3 truePos;
    public float gridSize;
    
    void LateUpdate()
    {
        truePos.x = Mathf.Floor(target.transform.position.x/gridSize)*gridSize;
        truePos.y = Mathf.Floor(target.transform.position.y / gridSize) * gridSize;
        truePos.z = Mathf.Floor(target.transform.position.z / gridSize) * gridSize;

        structure.transform.position = truePos;
    }*/

    //smooth camera
    /*public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }*/


    // player movement
    private float moveSpeed;
    public GameObject player;
    private bool onGround;

    // Use this for initialization
    void Start()
    {
        moveSpeed =1f;
    }

    // Update is called once per frame
    void Update()
    {
        //jump action
        if(onGround && Input.GetKey(KeyCode.Space)) {
            Jump();
            onGround = false;
        }
        else {
            if (player.transform.position.y >= 0.5f)
            {
                Vector3 downForce = new Vector3(0, -4.6f, 0);
                player.transform.Translate(downForce * Time.deltaTime);
            }
            onGround = true;
        }
        //update player position
        player.transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);

    }

    public void Jump()
    {

        float jumpSpeed=1f;
        float yPosition = 0.5f;
        // Don't let player fall through floor
        if (player.transform.position.y <= 0.5f)
        {
            jumpSpeed = 0.0f;
        }
        else
        {
            jumpSpeed -= 9.8f * Time.deltaTime;
            yPosition += jumpSpeed * Time.deltaTime;
        }
        // Translate y-position with max height jump
        if (player.transform.position.y <= 5f) { player.transform.Translate(new Vector3(0, yPosition, 0)); }
    }
}
