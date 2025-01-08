using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerial : MonoBehaviour
{
    public void goToLevels() // go to "level choose" menu
    {
        SceneManager.LoadSceneAsync("LevelChoose");
    }

    public void goToMenu() // go to "main menu"
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void goToLevel1()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
}
