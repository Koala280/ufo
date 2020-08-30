using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float respawnTime = 1.0f;
    public Rigidbody2D rb;
    private Camera mainCamera;
    public Vector2 heightThreshold;
    public Vector2 widthThreshold;

    void Start()
    {
        /* Move Bullet up */
        rb.velocity = transform.up * speed;
    }

    void Update() {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height + 90 || screenPosition.y < 0 )
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag.Equals("Asteroid"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        } else if (!col.gameObject.tag.Equals("Player")) /* FirePoint is on Player */
        {
            Destroy(gameObject);
        }
    }

}
