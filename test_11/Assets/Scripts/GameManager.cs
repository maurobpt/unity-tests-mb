using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void CompleteLevel()
    {
        Debug.Log("LEVEL WON! "+ SceneManager.GetActiveScene().name);
        //Debug.Log(completeLevelUI.name);
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded ==false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            //Restart game
            //Restart();
            Invoke("Restart",restartDelay);
        }
    }
    void Restart() {
        Debug.Log("RESTART");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
