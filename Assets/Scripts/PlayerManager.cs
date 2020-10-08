using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public GameObject gameOverText, restartButton, mainMenuButton;
    public Transform firePoint;
    public GameObject bullet_1_prefab;
    public GameObject bullet_2_prefab;
    public GameObject star_picked_prefab;
    private float raygun_cd_left = 0;
    private float raygun_shooting_repeat_rate;
    private float raygun_cooldown;
    private float star_cd_left = 0;
    private float star_speed;
    private float star_cooldown;
    private bool supermode = false;

    private void Start()
    {
        instance = this;

        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);

        raygun_shooting_repeat_rate = PlayerPrefs.GetFloat("raygun_shooting_repeat_rate", 1.0f);
        raygun_cooldown = PlayerPrefs.GetFloat("raygun_cooldown", 10.0f);

        /* TODO */
        star_speed = PlayerPrefs.GetFloat("star_speed", 7.0f);
        star_cooldown = PlayerPrefs.GetFloat("star_cooldown", 10.0f);
    }

    void Update()
    {
        /* Cooldown Timer */
        if (raygun_cd_left >= 0)
        {
            raygun_cd_left -= Time.deltaTime;
        }
        if (star_cd_left >= 0)
        {
            star_cd_left -= Time.deltaTime;

            if (star_cd_left <= 0)
            {
                Destroy(star_picked_prefab);
                GameSpeed.instance.gameSpeed -= star_speed;
                supermode = false;
            }
        }
    }

    public void Pickup(GameObject obj)
    {
        switch (obj.name)
        {
            case "Raygun_Prefab(Clone)":
                raygun_cd_left += raygun_cooldown;
                InvokeRepeating("Raygun_shoot", 0.1f, raygun_shooting_repeat_rate);
                break;
            case "Star_Prefab(Clone)":
                star_cd_left += star_cooldown;
                Star_attack();
                break;
            default:
                Debug.LogWarning($"WARNING: no Handler implemented for object name: ({obj.name})");
                break;
        }
    }

    void Star_attack()
    {
        Instantiate(star_picked_prefab, transform.position, transform.rotation);
        GameSpeed.instance.gameSpeed += star_speed;
        supermode = true;
        star_picked_prefab = GameObject.Find("Star_Picked_Prefab Variant(Clone)");
    }

    private void Raygun_shoot()
    {
        /* Spawn Bullet */
        Instantiate(bullet_1_prefab, firePoint.position, firePoint.rotation);
        /* When cooldown is ready stop loop */
        if (raygun_cd_left <= 0)
        {
            CancelInvoke("Raygun_shoot");
        }
    }

    /* Game Over if collide with Tag: Asteroid */
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid"))
        {
            /* If star_attack activated unkillable */
            if (!supermode)
            {
                this.GameOver();
            } else
            {
                Score.instance.score_value += 500;
                Destroy(col.gameObject);
            }
            
        }
    }


    void GameOver()
    {
        gameOverText.SetActive(true);
        restartButton.SetActive(true);
        mainMenuButton.SetActive(true);
        gameObject.SetActive(false);

        /* Deactivate Weapons */
        CancelInvoke();

        if (PlayerPrefs.GetInt("Highscore_first", 0) < Score.instance.score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", PlayerPrefs.GetInt("Highscore_second", 0));
            PlayerPrefs.SetInt("Highscore_second", PlayerPrefs.GetInt("Highscore_first", 0));
            PlayerPrefs.SetInt("Highscore_first", Score.instance.score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("Highscore_username_second", "guest"));
            PlayerPrefs.SetString("Highscore_username_second", PlayerPrefs.GetString("Highscore_username_first", "guest"));
            PlayerPrefs.SetString("Highscore_username_first", PlayerPrefs.GetString("username", "guest"));
        }

        if (PlayerPrefs.GetInt("Highscore_second", 0) < Score.instance.score_value && PlayerPrefs.GetInt("Highscore_first", 0) > Score.instance.score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", PlayerPrefs.GetInt("Highscore_second", 0));
            PlayerPrefs.SetInt("Highscore_second", Score.instance.score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("Highscore_username_second", "guest"));
            PlayerPrefs.SetString("Highscore_username_second", PlayerPrefs.GetString("username", "guest"));
        }

        if (PlayerPrefs.GetInt("Highscore_third", 0) < Score.instance.score_value && PlayerPrefs.GetInt("Highscore_second", 0) > Score.instance.score_value)
        {
            PlayerPrefs.SetInt("Highscore_third", Score.instance.score_value);

            PlayerPrefs.SetString("Highscore_username_third", PlayerPrefs.GetString("username", "guest"));
        }

        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money", 0) + Score.instance.score_value);
        Score.instance.game_over = true;
    }
}
