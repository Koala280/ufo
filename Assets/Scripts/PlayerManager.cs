using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private void Start()
    {
        instance = this;
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
        LayoutManager.instance.GameOver();

        Score.instance.UpdateHighscoreValue();

        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) + Score.instance.score_value);
        GameScript.instance.game_running = false;
    }
}
