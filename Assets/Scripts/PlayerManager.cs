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

        if (PlayerPrefs.GetInt("Highscore_first", 0) < Score.instance.score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", PlayerPrefs.GetInt("Highscore_second", 0));
            PlayerPrefs.SetInt("Highscore_second", PlayerPrefs.GetInt("Highscore_first", 0));
            PlayerPrefs.SetInt("Highscore_first", Score.instance.score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("Highscore_username_second", "guest"));
            PlayerPrefs.SetString("Highscore_username_second", PlayerPrefs.GetString("Highscore_username_first", "guest"));
            PlayerPrefs.SetString("Highscore_username_first", PlayerPrefs.GetString("username", "guest"));
        }

        if (PlayerPrefs.GetInt("Highscore_second", 0) < Score.instance.score_value && PlayerPrefs.GetInt("Highscore_first", 0) > Score.instance.score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", PlayerPrefs.GetInt("Highscore_second", 0));
            PlayerPrefs.SetInt("Highscore_second", Score.instance.score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("Highscore_username_second", "guest"));
            PlayerPrefs.SetString("Highscore_username_second", PlayerPrefs.GetString("username", "guest"));
        }

        if (PlayerPrefs.GetInt("Highscore_third", 0) < Score.instance.score_value && PlayerPrefs.GetInt("Highscore_second", 0) > Score.instance.score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", Score.instance.score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("username", "guest"));
        }

        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) + Score.instance.score_value);
        Score.instance.game_over = true;
    }
}
