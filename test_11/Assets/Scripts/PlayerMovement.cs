using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 1000f;
    public float sidewaysForce = 500f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hello, world!");
        //rb.AddForce(0,200,500);
    }

    // FixedUpdate is used for physics
    void FixedUpdate()
    {
        rb.AddForce(0,0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y<-1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
