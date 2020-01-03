using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public float restartDelay = 3;

    public void FailedGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;

            Invoke("RestartScreen", restartDelay);
        }
    }

    void RestartScreen()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Retry()
    {
        SceneManager.LoadScene("Room 1");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
}
