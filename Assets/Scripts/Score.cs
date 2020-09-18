using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instace;
    public int score_value;
    private float score_distance;
    public int score_add;
    private TextMeshProUGUI score_text;
    // Start is called before the first frame update
    void Start()
    {
        instace = this;
        score_value = 0;
        score_text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Score through the distance multiplied */
        score_distance = Camera.main.transform.position.y * 20;
        score_value = Mathf.RoundToInt(score_distance) + score_add;
        /* Update Score Text */
        score_text.text = score_value.ToString();
    }
}


/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static float score_value;
    private TextMeshPro score_text;
    // Start is called before the first frame update
    void Start()
    {
        score_value = 0;
        score_text = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        score_value += 1;
        /* 0:0 <= first value rounded to an int 
        score_text.SetText("{0:0}", score_value);
    }
} */