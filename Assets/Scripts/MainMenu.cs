using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Start()
    {
        highScoreText.SetText(PlayerPrefs.GetInt("HighScore").ToString());
    }
}
