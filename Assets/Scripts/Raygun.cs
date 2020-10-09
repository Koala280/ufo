using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raygun : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject firePoint;
    public GameObject bullet_1_prefab;
    private float cooldown_left;
    private float shooting_repeat_rate;
    private float cooldown;


    void Start()
    {
        firePoint = GameObject.Find("FirePoint");
        cooldown = PlayerPrefs.GetFloat("raygun_cooldown", 10.0f);
        shooting_repeat_rate = PlayerPrefs.GetFloat("raygun_shooting_repeat_rate", 1.0f);
    }


    void Update()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -GameSpeed.instance.gameSpeed + 0.5f);
        if (transform.position.y < -7.5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            Start_Raygun();
        }
    }

    void Start_Raygun()
    {
        cooldown_left += cooldown;
        InvokeRepeating("Raygun_shoot", 0, shooting_repeat_rate);
    }

    private void Raygun_shoot()
    {
        /* Spawn Bullet */
        Instantiate(bullet_1_prefab, firePoint.transform.position, firePoint.transform.rotation);
        cooldown_left -= shooting_repeat_rate;
        /* When cooldown is ready stop loop */
        if (cooldown_left <= 0)
        {
            CancelInvoke("Raygun_shoot");
            Destroy(gameObject);
        }
    }
}
