using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        if (rb.position.y > screenBounds.y + 2)
        {
            //TODO OBJECTPOOLER
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid"))
        {
            Score.instance.AsteroidDestroyed();
            col.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
}
