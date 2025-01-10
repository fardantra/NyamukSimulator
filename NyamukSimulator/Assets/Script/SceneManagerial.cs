using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerial : MonoBehaviour
{
    public void goToMenu() // go to "main menu"
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void goToPlay() // go play the game
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
