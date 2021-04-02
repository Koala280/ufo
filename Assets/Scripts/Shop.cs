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
    
    private int star_lvl;
    public TextMeshProUGUI star_lvl_txt;
    private int star_price;
    public TextMeshProUGUI star_price_txt;

    private int nuclear_lvl;
    public TextMeshProUGUI nuclear_lvl_txt;
    private int nuclear_price;
    public TextMeshProUGUI nuclear_price_txt;

    private float raygun_shooting_repeat_rate;
    private float raygun_cooldown;
    public int raygun_lvl_price;
    public int star_lvl_price;
    public int nuclear_lvl_price;

    void OnEnable()
    {
        /* Get Money Value */
        money_value = PlayerPrefs.GetInt("money", 0);
        money_txt.SetText($"Current Value: {money_value}");

        /* Get Raygun LVL and price */
        raygun_lvl = PlayerPrefs.GetInt("raygun_lvl", 1);
        raygun_lvl_txt.SetText($"{raygun_lvl}");
        raygun_price = raygun_lvl * raygun_lvl_price;
        raygun_price_txt.SetText($"{raygun_price}");

        /* Get Star LVL and Price */
        star_lvl = PlayerPrefs.GetInt("star_lvl", 1);
        star_lvl_txt.SetText($"{star_lvl}");
        star_price = star_lvl * star_lvl_price;
        star_price_txt.SetText($"{star_price}");

        /* Get Nuclear LVL and Price */
        nuclear_lvl = PlayerPrefs.GetInt("nuclear_lvl", 1);
        nuclear_lvl_txt.SetText($"{nuclear_lvl}");
        nuclear_price = nuclear_lvl * nuclear_lvl_price;
        nuclear_price_txt.SetText($"{nuclear_price}");
    }

    public void UpgradeRaygun()
    {
        /* lvl 9 is max faster to fire is impossible */
        if (money_value >= raygun_price && raygun_lvl < 10)
        {
            /* Increase Raygun Cooldown and shooting rate */
            PlayerPrefs.SetFloat("raygun_cooldown", PlayerPrefs.GetFloat("raygun_cooldown", 10.0f) + 1.0f);
            PlayerPrefs.SetFloat("raygun_shooting_repeat_rate", PlayerPrefs.GetFloat("raygun_shooting_repeat_rate", 1.0f) - 0.1f);

            /* Increase Lvl of Raygun */
            raygun_lvl += 1;
            PlayerPrefs.SetInt("raygun_lvl", raygun_lvl);
            raygun_lvl_txt.SetText($"{raygun_lvl}");

            /* Decrease Money value */
            money_value -= raygun_price;
            PlayerPrefs.SetInt("money", money_value);
            money_txt.SetText($"Current Value: {money_value}");

            /* Get new Price */
            raygun_price = raygun_lvl * raygun_lvl_price;
            raygun_price_txt.SetText($"{raygun_price}");

            GPGSSaveGameState.instance.OpenSave(true);
        }
    }

    public void UpgradeStar()
    {
        if (money_value >= star_price)
        {
            /* Increase Star Running time and Size */
            PlayerPrefs.SetFloat("star_cooldown", PlayerPrefs.GetFloat("star_cooldown", 10.0f) + 1.0f);
            PlayerPrefs.SetFloat("star_size", PlayerPrefs.GetFloat("star_size", 0.2f) + 0.05f);

            /* LVL Up the star */
            star_lvl += 1;
            PlayerPrefs.SetInt("star_lvl", star_lvl);
            star_lvl_txt.SetText($"{star_lvl}");

            /* decrease Money value by star price */
            money_value -= star_price;
            PlayerPrefs.SetInt("money", money_value);
            money_txt.SetText($"Current Value: {money_value}");

            /* Update new Star price */
            star_price = star_lvl * star_lvl_price;
            star_price_txt.SetText($"{star_price}");

            GPGSSaveGameState.instance.OpenSave(true);
        }
    }

    public void UpgradeNuclear()
    {
        if (money_value >= nuclear_price && nuclear_lvl < 10)
        {
            /* Increase Nuclear Running time and Size */
            PlayerPrefs.SetFloat("nuclear_cooldown", PlayerPrefs.GetFloat("nuclear_cooldown", 2.0f) + 1.0f);
            PlayerPrefs.SetFloat("nuclear_size", PlayerPrefs.GetFloat("nuclear_size", 0.2f) + 0.05f);

            /* LVL Up the nuclear */
            nuclear_lvl += 1;
            PlayerPrefs.SetInt("nuclear_lvl", nuclear_lvl);
            nuclear_lvl_txt.SetText($"{nuclear_lvl}");

            /* decrease Money value by nuclear price */
            money_value -= nuclear_price;
            PlayerPrefs.SetInt("money", money_value);
            money_txt.SetText($"Current Value: {money_value}");

            /* Update new nuclear price */
            nuclear_price = nuclear_lvl * nuclear_lvl_price;
            nuclear_price_txt.SetText($"{nuclear_price}");

            GPGSSaveGameState.instance.OpenSave(true);
        }
    }
}
