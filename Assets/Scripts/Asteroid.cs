/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D asteroid;
    public float moveSpeed;
    public float randomMoveSpeed;
    public float rotateSpeed;
    private float size;

    // TODO better in OnEnable or in Update???
    void OnEnable()
    {
        asteroid = GetComponent<Rigidbody2D>();
        SetAsteroidSize();
        rotateSpeed = Random.Range(-80f, 80f);
        randomMoveSpeed = Random.Range(GameScript.instance.gameSpeed / 4f, GameScript.instance.gameSpeed * 2f);
    }

    void Update()
    {
        moveSpeed = randomMoveSpeed * GameScript.instance.gameSpeed;
    }

    void FixedUpdate()
    {
        if (transform.position.y < -7.5f)
        {
            DestroyAsteroid();
        }
        
        /* asteroid.velocity = -transform.up * moveSpeed * Time.fixedDeltaTime / 10;
        asteroid.MoveRotation(asteroid.rotation + rotateSpeed * Time.fixedDeltaTime);
 

        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime, Space.Self); //rotate
        transform.Translate(0, -moveSpeed * Time.deltaTime / 10, 0, Space.World);  //move 
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
} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rb;
    private float rotateSpeed;
    private float size;
    public float newMagnitude;
    public float moveSpeed;

    void OnEnable()
    {
        rb = transform.GetComponent<Rigidbody2D>();

        rotateSpeed = Random.Range(-3.0f, 3.0f);
        //

        //Move rb
        //rb.velocity = transform.up * moveSpeed;




        /* newMagnitude = Mathf.Clamp(rb.velocity.magnitude + Random.Range(-0.1f, 0.1f), -GameScript.instance.gameSpeed / 4f, -GameScript.instance.gameSpeed * 3f);*/




        //rb.velocity = rb.transform.up.normalized * 10;

        //Set rb Size
        SetrbSize();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.rotation += rotateSpeed;

        if (transform.position.y < -7.5f)
        {
            gameObject.SetActive(false);
        }

        //moveSpeed = rb.velocity.magnitude + Random.Range(-GameScript.instance.gameSpeed / 4f, -GameScript.instance.gameSpeed * 3f);
        //newMagnitude = Mathf.Clamp(rb.velocity.magnitude + Random.Range(-0.1f, 0.1f), -GameScript.instance.gameSpeed / 4f, -GameScript.instance.gameSpeed * 3f);
        // newMagnitude = Mathf.Clamp(rb.velocity.magnitude + Random.Range(-0.1f, 0.1f), -GameScript.instance.gameSpeed / 4f, -GameScript.instance.gameSpeed * 3f);
        //rb.velocity = rb.velocity.normalized * 10f;

//        rb.velocity = rb.velocity * 0.1f;

        //moveSpeed = Random.Range(-GameScript.instance.gameSpeed / 4f, -GameScript.instance.gameSpeed * 3f);
    }

    void SetrbSize()
    {
        size = Random.Range(0.09f, 0.17f);
        transform.localScale = new Vector3(size, size, 0);
    }
}