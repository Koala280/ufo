using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D asteroid;
    private Vector3 eulerAngleVelocity;
    private float moveSpeed;
    private float rotateSpeed;
    private float size;

    // TODO better in OnEnable or in Update???
    void OnEnable()
    {
        asteroid = transform.GetComponent<Rigidbody2D>();
        eulerAngleVelocity = new Vector3(0, 0, 100);
        rotateSpeed = Random.Range(-3.0f, 3.0f);
        SetAsteroidSize();
    }

    void FixedUpdate()
    {
        if (transform.position.y < -7.5f)
        {
            DestroyAsteroid();
        }
        asteroid.rotation += rotateSpeed;
        asteroid.velocity = transform.up * Random.Range(-GameScript.instance.gameSpeed / 4f, -GameScript.instance.gameSpeed * 3f) * Time.deltaTime;
    }


    void DestroyAsteroid()
    {
        gameObject.SetActive(false);
    }

    void SetAsteroidSize()
    {
        size = Random.Range(0.09f, 0.17f);
        transform.localScale = new Vector3(size, size, 0);
    }
}