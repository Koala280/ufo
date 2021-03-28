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
    public float starMaxSize = 1.2f;
    
    void Start()
    {
        player = GameObject.Find("Player");

        added_speed = PlayerPrefs.GetFloat("star_speed", 7.0f);
        cooldown = PlayerPrefs.GetFloat("star_cooldown", 10.0f);
        size = PlayerPrefs.GetFloat("star_size", 0.2f);
        if (size > starMaxSize)
        {
            size = starMaxSize;
        }
    }
    void FixedUpdate()
    {
        if (transform.position.y < -7.5f)
        {
            DestroyStar();
        }

        if (cooldown_left > 0)
        {
            RotateStarOnPlayer();
        }
        else
        {
            rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -GameScript.instance.gameSpeed + 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid") && cooldown_left > 0)
        {
            Score.instance.score_value += 500;
            col.gameObject.SetActive(false);
        }
        if (col.gameObject.name == "Player")
        {
            Start_Star();
        }
    }

    public void Start_Star()
    {
        player.GetComponent<PolygonCollider2D>().enabled = false;
        GameScript.instance.gameSpeed += added_speed;
        cooldown_left += cooldown;
    }

    void RotateStarOnPlayer()
    {
        cooldown_left -= Time.deltaTime;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
        transform.Rotate(0, 0, 13);
        transform.localScale = new Vector3(size, size, 0);

        if (cooldown_left <= 0)
        {
            player.GetComponent<PolygonCollider2D>().enabled = true;
            GameScript.instance.gameSpeed -= added_speed;
            DestroyStar();
        }
    }

    void DestroyStar()
    {
        gameObject.SetActive(false);
    }
}
