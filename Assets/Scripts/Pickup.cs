using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject deletepoint;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -GameSpeed.instance.gameSpeed + 0.5f);
        deletepoint = GameObject.Find("Deletepoint");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager manager = collision.GetComponent<PlayerManager>();
        if (manager)
        {
            Destroy(gameObject);
            manager.Pickup(gameObject);
        }
    }

    void Update()
    {

        if (transform.position.y < deletepoint.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
