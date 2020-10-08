using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static GameSpeed instance;
    public GameObject cameraBottom;
    public float gameSpeed; 
    public float speedCameraPosition;
    public float speed_playerposition;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        /* Increase Background Movement Speed depending on y-achsis Position & Score*/
        if (gameSpeed < 8)
        {
            gameSpeed = (Score.instance.score_value / 10000) + ((transform.position.y - cameraBottom.transform.position.y) / 2f);
        }

        if (gameSpeed < 2)
        {
            gameSpeed = 2.3f;
        }
    }
}
