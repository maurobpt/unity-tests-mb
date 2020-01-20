using UnityEngine;
using UnityEngine.SceneManagement;

public class Welcome : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("WELCOME - START GAME");
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
    }
}
