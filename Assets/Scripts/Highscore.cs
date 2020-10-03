using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{

    public TextMeshProUGUI highscore_first;
    public TextMeshProUGUI highscore_second;
    public TextMeshProUGUI highscore_third;
    void Start()
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
}
