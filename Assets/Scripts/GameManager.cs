using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private AudioManager audioManager;
    private int playerScore;
    [SerializeField] private TextMeshProUGUI playerScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;

    private bool isAlive = true;

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
            
    }

    [ContextMenu("Increase Score")]
    public void addScore(int value)
    {
        if (!isBirdAlive()) return; //Makes sure you cannot score if in gameover state

        playerScore += value;
        playerScoreText.SetText(playerScore.ToString());
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        if (!isBirdAlive()) return; //No need to die again

        audioManager.Play("BonkSound");
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
        highScoreText.SetText(PlayerPrefs.GetInt("HighScore").ToString());

        gameOverScreen.SetActive(true);
        isAlive = false;
    }

    public bool isBirdAlive()
    {
        return isAlive;
    }
}
