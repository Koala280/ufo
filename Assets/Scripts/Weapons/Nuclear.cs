using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuclear : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject[] asteroids;
    private float cooldown;
    private float cooldown_left;
    private float nuclear_activation_rate = 0.2f;
    public GameObject explosion;

    void Start()
    {
        cooldown = PlayerPrefs.GetFloat("nuclear_cooldown", 3.0f);
    }

    void OnEnable()
    {
        transform.Rotate(0, 0, 270);
    }

    void FixedUpdate()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -GameScript.instance.gameSpeed + 0.5f);
        if (transform.position.y < -7.5f)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Start_Nuclear();
        }
    }

    public void Start_Nuclear()
    {
        cooldown_left += cooldown;
        gameObject.SetActive(false);
        InvokeRepeating("Nuclear_Active", 0, nuclear_activation_rate);
    }

    void Nuclear_Active()
    {
        cooldown_left -= nuclear_activation_rate;
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (var asteroid in asteroids)
        {
            asteroid.SetActive(false);
            Score.instance.score_value += 500;
        }
        if (cooldown_left >= 1)
        {
            Instantiate(explosion, Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 10)), Quaternion.identity);
        }
        if (cooldown_left <= 0 || !GameScript.instance.game_running)
        {
            CancelInvoke("Nuclear_Active");
        }
    }
}
