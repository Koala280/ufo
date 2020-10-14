using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject gameOverText, restartButton, mainMenuButton;

    private void Start()
    {
        instance = this;

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
    }

    /* Game Over if collide with Tag: Asteroid */
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
        gameObject.SetActive(false);

        Score.instance.UpdateHighscoreValue();

        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) + Score.instance.score_value);
        GameScript.instance.game_running = false;
    }
}
