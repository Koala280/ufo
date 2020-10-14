using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public static GameScript instance;
    public GameObject player;
    public float gameSpeed;
    public bool game_running;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        /* Increase Background Movement Speed depending on y-achsis Position & Score*/
        if (game_running)
        {
            if (gameSpeed < 8)
            {
                gameSpeed = (Score.instance.score_value / 10000) + ((player.transform.position.y + 7.5f) / 2f);
            }

            if (gameSpeed < 2)
            {
                gameSpeed = 2.3f;
            }
        }
    }
}
