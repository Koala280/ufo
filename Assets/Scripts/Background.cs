using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float distance;
    void Update()
    {
        distance = (GameSpeed.instance.gameSpeed * Time.deltaTime) * 1.5f;
        transform.Translate(0, -distance, 0);
        if (transform.position.y <= -43.50f)
        {
            transform.Translate(0, 43.50f * 2, 0);
        }
        Score.instance.score_value += Mathf.RoundToInt(distance * 10);
    }
}