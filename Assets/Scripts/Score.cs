using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score_value;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI highscore_first;
    public TextMeshProUGUI highscore_second;
    public TextMeshProUGUI highscore_third;
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

    public void UpdateHighscoreValue()
    {
        if (PlayerPrefs.GetInt("Highscore_first", 0) < score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", PlayerPrefs.GetInt("Highscore_second", 0));
            PlayerPrefs.SetInt("Highscore_second", PlayerPrefs.GetInt("Highscore_first", 0));
            PlayerPrefs.SetInt("Highscore_first", score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("Highscore_username_second", "guest"));
            PlayerPrefs.SetString("Highscore_username_second", PlayerPrefs.GetString("Highscore_username_first", "guest"));
            PlayerPrefs.SetString("Highscore_username_first", PlayerPrefs.GetString("username", "guest"));
        }

        if (PlayerPrefs.GetInt("Highscore_second", 0) < score_value && PlayerPrefs.GetInt("Highscore_first", 0) > score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", PlayerPrefs.GetInt("Highscore_second", 0));
            PlayerPrefs.SetInt("Highscore_second", score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("Highscore_username_second", "guest"));
            PlayerPrefs.SetString("Highscore_username_second", PlayerPrefs.GetString("username", "guest"));
        }

        if (PlayerPrefs.GetInt("Highscore_third", 0) < score_value && PlayerPrefs.GetInt("Highscore_second", 0) > score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("username", "guest"));
        }
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
    void UpdateHighscoreText()
    {
        int highscore_value_first = PlayerPrefs.GetInt("Highscore_first", 0);
        int highscore_value_second = PlayerPrefs.GetInt("Highscore_second", 0);
        int highscore_value_third = PlayerPrefs.GetInt("Highscore_third", 0);

        string highscore_username_first = PlayerPrefs.GetString("Highscore_username_first", "guest");
        string highscore_username_second = PlayerPrefs.GetString("Highscore_username_second", "guest");
        string highscore_username_third = PlayerPrefs.GetString("Highscore_username_third", "guest");

        highscore_first.SetText($"{highscore_username_first}: {highscore_value_first}");
        highscore_second.SetText($"{highscore_username_second}: {highscore_value_second}");
        highscore_third.SetText($"{highscore_username_third}: {highscore_value_third}");
    }

    public void AddScore(int value)
    {
        score_value += value;
    }
}