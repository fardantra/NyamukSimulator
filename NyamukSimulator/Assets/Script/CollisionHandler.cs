using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Untuk ganti scene ketika level complete

public class CollisionHandler : MonoBehaviour
{
    static public int amoebaEaten = 0;
    public int amoebaToEat = 10; // Target complete level

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Amoeba"))
        {
            amoebaEaten++;
            Destroy(collision.gameObject);

            if (amoebaEaten >= amoebaToEat)
            {
                LevelComplete();
            }
        }
        else if (collision.CompareTag("Fish") || collision.CompareTag("Frog"))
        {
            GameOver();
        }
    }

    void LevelComplete()
    {
        Debug.Log("Level Completed!");
        SceneManager.LoadScene("SampleScene");
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
