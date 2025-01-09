using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    static public int amoebaEaten = 0;
    public int amoebasToEat = 10; // Target score to display high score (optional)
    public UIManager uiManager;

    void Awake()
    {
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
            if (uiManager == null)
            {
                Debug.LogError("UIManager not found in the scene!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Amoeba"))
        {
            amoebaEaten++;
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Fish") || collision.CompareTag("Frog"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Cursor.visible = true;
        Debug.Log("Game Over!");

        if (uiManager != null)
        {
            uiManager.UpdateHighScore();  // Update the high score if necessary
            uiManager.UpdateHighScoreUI(); // Refresh the high score UI
        }
        else
        {
            Debug.LogError("UIManager is not assigned in CollisionHandler!");
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        if (uiManager != null)
        {
            uiManager.ResetScore(); // Reset the current score
        }
    }
}
