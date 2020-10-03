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
        /* Move Bullet up */
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (rb.position.y > screenBounds.y + 1)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid"))
        {
            Score.instance.score_value += 500;
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}
