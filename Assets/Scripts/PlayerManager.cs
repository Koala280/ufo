using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameOverText, restartButton, mainMenuButton;
    public Transform firePoint;
    public GameObject bullet_prefab;
    private float raygun_cd_left = 0;
    public float raygun_shooting_repeat_rate = 1.0f;
    public float raygun_cooldown = 15.0f;
    private float star_cd_left = 0;
    public float star_cooldown = 10.0f;

    private void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
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
        }
    }

    public void Pickup(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Raygun":
                /* Start cooldown */
                raygun_cd_left += raygun_cooldown;
                /* Start shooting loop */
                InvokeRepeating("Raygun_shoot", 0.1f, raygun_shooting_repeat_rate);
                break;
            case "Star":
                star_cd_left += star_cooldown;
                break;

            default:
                Debug.LogWarning($"WARNING: no Handler implemented for object tag: {obj.tag}!!!");
                break;
        }
    }

    private void Raygun_shoot()
    {
        /* Spawn Bullet */
        Instantiate(bullet_prefab, firePoint.position, firePoint.rotation);
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
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            mainMenuButton.SetActive(true);
            gameObject.SetActive(false);
            raygun_cd_left = 0;
        }
    }
}
