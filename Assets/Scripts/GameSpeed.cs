using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static GameSpeed instance;
    private Rigidbody2D rb;
    public GameObject cameraBottom;
    public float gameSpeed; 
    public float speedCameraPosition;
    public float speed_playerposition;
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        /* Increase Camera Movement Speed depending on y Position*/
        if (gameSpeed < 8 && gameSpeed > 2)
        {
            gameSpeed = (Score.instance.score_value) + ((rb.position.y - cameraBottom.transform.position.y) / speed_playerposition);
        }

        if (gameSpeed < 2)
        {
            gameSpeed = 2f;
        }
    }
}
