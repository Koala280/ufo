using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float distance;
    private int add_value;
    void Update()
    {
        distance = (GameSpeed.instance.gameSpeed * Time.deltaTime) * 1.5f;
        transform.Translate(0, -distance, 0);
        if (transform.position.y <= -43.50f)
        {
            transform.Translate(0, 43.50f * 2, 0);
        }

        add_value = Mathf.RoundToInt(distance * 10);
        if(add_value < 1)
        {
            Score.instance.score_value += 1;
        }
        Score.instance.score_value += add_value;
    }
}