using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D bullet;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        bullet = transform.GetComponent<Rigidbody2D>();
        bullet.velocity = transform.up * speed;
    }

    void Update()
    {
        if (bullet.position.y > screenBounds.y + 2)
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
