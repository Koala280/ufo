using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D rb;
    private GameObject deletepoint;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        deletepoint = GameObject.Find("Deletepoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < deletepoint.transform.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}