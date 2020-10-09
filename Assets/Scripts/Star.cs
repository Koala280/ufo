using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private float cooldown_left;
    private float added_speed;
    private float cooldown;
    private float size;
    void Start()
    {
        player = GameObject.Find("Player");

        added_speed = PlayerPrefs.GetFloat("star_speed", 7.0f);
        cooldown = PlayerPrefs.GetFloat("star_cooldown", 10.0f);
        size = PlayerPrefs.GetFloat("star_size", 0.2f);
    }
    void Update()
    {
        if (transform.position.y < -7.5f)
        {
            Destroy(gameObject);
        }

        if (cooldown_left > 0)
        {
            cooldown_left -= Time.deltaTime;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
            transform.Rotate(0, 0, 13);
            transform.localScale = new Vector3(size, size, 0);

            if (cooldown_left <= 0)
            {
                player.GetComponent<PolygonCollider2D>().enabled = true;
                GameSpeed.instance.gameSpeed -= added_speed;
                Destroy(gameObject);
            }
        }
        else
        {
            rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -GameSpeed.instance.gameSpeed + 0.5f);
        }
    }

    /* void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid"))
        {
            Score.instance.score_value += 500;
            Destroy(col.gameObject);
        }
    } */

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid") && cooldown_left > 0)
        {
            Score.instance.score_value += 500;
            Destroy(col.gameObject);
        }
        if (col.gameObject.name == "Player")
        {
            Start_Star();
        }
    }

    public void Start_Star()
    {
        player.GetComponent<PolygonCollider2D>().enabled = false;
        GameSpeed.instance.gameSpeed += added_speed;
        cooldown_left += cooldown;
    }

}
