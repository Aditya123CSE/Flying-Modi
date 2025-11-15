using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public HighScoreManager highScoreManager;
     void Start()
    {
        // Find the HighScoreManager script on the same GameObject
        highScoreManager = GetComponent<HighScoreManager>();
    }
 
    [ContextMenu("Increase Score")]

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
 
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
     public void gameOver()
    {
        // 1. Check if a new high score was set
        if (highScoreManager != null)
        {
            highScoreManager.CheckAndSetHighScore(playerScore);
        }

        // 2. Show the game over screen
        gameOverScreen.SetActive(true);
    }
}