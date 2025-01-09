using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreText;       // Displays the current score
    public Text HighScoreText;   // Displays the high score

    void Start()
    {
        ResetScore();           // Reset the score at the start
        UpdateHighScoreUI();    // Display the high score at the start
    }

    void Update()
    {
        ScoreText.text = CollisionHandler.amoebaEaten.ToString(); // Update current score
    }

    public void ResetScore()
    {
        CollisionHandler.amoebaEaten = 0; // Reset the score value
        ScoreText.text = "0"; // Update the UI to reflect the reset value
    }

    public void UpdateHighScore()
    {
        // Check if the current score is greater than the high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // Get the saved high score
        if (CollisionHandler.amoebaEaten > highScore)
        {
            PlayerPrefs.SetInt("HighScore", CollisionHandler.amoebaEaten); // Save new high score
            PlayerPrefs.Save(); // Ensure it persists
        }
    }

    public void UpdateHighScoreUI()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // Get the saved high score
        HighScoreText.text = highScore.ToString();    // Update the high score UI
    }
}
