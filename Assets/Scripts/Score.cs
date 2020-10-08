using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score_value;
    private TextMeshProUGUI score_text;
    public bool game_over;
    // Start is called before the first frame update
    void Start()
    {
        /* So i can get the Score in other Scripts (Score.instance.score_value) */
        instance = this;
        score_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Update Score Text */
        if (!game_over)
        {
            if (score_value <= 0)
            {
                score_value = 0;
            }
            score_text.text = score_value.ToString();
        }
    }
}