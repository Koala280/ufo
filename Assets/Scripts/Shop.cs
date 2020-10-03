using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{

    public int money_value;
    public TextMeshProUGUI money_txt;
    private int raygun_lvl;
    public TextMeshProUGUI raygun_lvl_txt;
    private int raygun_price;
    public TextMeshProUGUI raygun_price_txt;
    private float raygun_shooting_repeat_rate;
    private float raygun_cooldown;

    void Start()
    {
        money_value = PlayerPrefs.GetInt("money", 0);
        money_txt.SetText($"Current Value: {money_value}");

        raygun_lvl = PlayerPrefs.GetInt("raygun_lvl", 1);
        raygun_lvl_txt.SetText($"{raygun_lvl}");
        raygun_price = raygun_lvl * 5000;
        raygun_price_txt.SetText($"{raygun_price}");
    }

    public void UpgradeRaygun()
    {
        /* till lvl 9. faster to fire is impossible */
        if (money_value >= raygun_price && raygun_lvl < 10)
        {
            PlayerPrefs.SetFloat("raygun_cooldown", PlayerPrefs.GetFloat("raygun_cooldown", 10.0f) + 1.0f);
            PlayerPrefs.SetFloat("raygun_shooting_repeat_rate", PlayerPrefs.GetFloat("raygun_shooting_repeat_rate", 1.0f) - 0.1f);

            raygun_lvl += 1;
            PlayerPrefs.SetInt("raygun_lvl", raygun_lvl);
            raygun_lvl_txt.SetText($"{raygun_lvl}");

            money_value -= raygun_price;
            PlayerPrefs.SetInt("money", money_value);
            money_txt.SetText($"Current Value: {money_value}");

            raygun_price = raygun_lvl * 10000;
            raygun_price_txt.SetText($"{raygun_price}");
        }
    }
}
