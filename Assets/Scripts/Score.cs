using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score_value;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI highscore1;
    public TextMeshProUGUI highscore2;
    public TextMeshProUGUI highscore3;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        UpdateHighscoreText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void UpdateHighscore()
    {
        /* If new Highscore */
        if (PlayerPrefs.GetInt("highscore1", 0) < score_value)
        {

            PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("highscore2", 0));
            PlayerPrefs.SetInt("highscore2", PlayerPrefs.GetInt("highscore1", 0));
            PlayerPrefs.SetInt("highscore1", score_value);

            PlayerPrefs.SetString("highscore3_username", PlayerPrefs.GetString("highscore2_username", "guest"));
            PlayerPrefs.SetString("highscore2_username", PlayerPrefs.GetString("highscore1_username", "guest"));
            PlayerPrefs.SetString("highscore1_username", PlayerPrefs.GetString("username", "guest"));
            GPGSLeaderboard.UpdateLeaderboardScore(score_value);
        }

        /* If new Second Place */
        if (PlayerPrefs.GetInt("highscore2", 0) < score_value && PlayerPrefs.GetInt("highscore1", 0) > score_value)
        {

            PlayerPrefs.SetInt("highscore3", PlayerPrefs.GetInt("highscore2", 0));
            PlayerPrefs.SetInt("highscore2", score_value);

            PlayerPrefs.SetString("highscore3_username", PlayerPrefs.GetString("highscore2_username", "guest"));
            PlayerPrefs.SetString("highscore2_username", PlayerPrefs.GetString("username", "guest"));
        }

        if (PlayerPrefs.GetInt("highscore3", 0) < score_value && PlayerPrefs.GetInt("highscore2", 0) > score_value)
        {

            PlayerPrefs.SetInt("highscore3", score_value);

            PlayerPrefs.SetString("highscore3_username", PlayerPrefs.GetString("username", "guest"));
        }

        GPGSSaveGameState.instance.OpenSave(true);

        UpdateHighscoreText();
        
    }

    void UpdateScore()
    {
        /* Update Score Text */
        if (GameScript.instance.game_running)
        {
            if (score_value <= 0)
            {
                score_value = 0;
            }
            score_text.text = score_value.ToString();
        }
    }

    /* Get Top 3 Highscores and set the Highscore Text*/
    public void UpdateHighscoreText()
    {
        int highscore1_value = PlayerPrefs.GetInt("highscore1", 0);
        int highscore2_value = PlayerPrefs.GetInt("highscore2", 0);
        int highscore3_value = PlayerPrefs.GetInt("highscore3", 0);

        string highscore1_username = PlayerPrefs.GetString("highscore1_username", "guest");
        string highscore2_username = PlayerPrefs.GetString("highscore2_username", "guest");
        string highscore3_username = PlayerPrefs.GetString("highscore3_username", "guest");

        highscore1.SetText($"{highscore1_username}: {highscore1_value}");
        highscore2.SetText($"{highscore2_username}: {highscore2_value}");
        highscore3.SetText($"{highscore3_username}: {highscore3_value}");
    }

    public void AddScore(int value)
    {
        score_value += value;
    }

    public void AsteroidDestroyed()
    {
        score_value += 500;
        GPGSAchievements.IncrementAsteroidAchievement();
    }
}