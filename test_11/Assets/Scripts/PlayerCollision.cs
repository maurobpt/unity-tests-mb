using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("We hit something");
        //Debug.Log(collision.collider.name);
        //collision.collider.name=="Obstacle"
        if (collision.collider.tag=="Obstacle")
        {
            Debug.Log("We hit an obstacle");
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
