using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    // Key used to save and retrieve the high score in PlayerPrefs
    private const string HighScoreKey = "HighScore"; 

    // Assign your UI Text component for displaying the High Score here
    public Text highScoreText;

    void Start()
    {
        // Load the stored high score when the game starts
        UpdateHighScoreDisplay();
    }

    // Public method to be called by LogicScript when a game ends
    public void CheckAndSetHighScore(int currentScore)
    {
        // 1. Get the current saved high score (defaults to 0 if not found)
        int savedHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        // 2. Check if the current score is greater than the saved high score
        if (currentScore > savedHighScore)
        {
            // 3. If it is, save the new score
            PlayerPrefs.SetInt(HighScoreKey, currentScore);
            PlayerPrefs.Save(); // Ensure the data is written to disk

            Debug.Log("New High Score: " + currentScore);
            
            // 4. Update the display immediately
            UpdateHighScoreDisplay();
        }
    }

    void UpdateHighScoreDisplay()
    {
        // Get the score again for display
        int highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        
        if (highScoreText != null)
        {
            // Update the UI text component
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
}