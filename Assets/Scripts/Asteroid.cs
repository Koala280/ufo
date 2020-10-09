using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, Random.Range(-GameSpeed.instance.gameSpeed / 4, -GameSpeed.instance.gameSpeed * 3f));
    }

    // Update is called once per frame
    void Update()
    {
        /* TODO fallgeschwindigkeit erhöhen rb.velocity.y += 1 */
        if (transform.position.y < -7.5f)
        {
            Destroy(this.gameObject);
        }


    }
}