using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float charMovementSpeed = 10f;
    public GameObject cameraBottom;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Increase Camera Movement Speed depending on y Position*/
        CameraMovement.instace.speed = (Camera.main.transform.position.y / 150) + (rb.position.y - cameraBottom.transform.position.y) / 7;

        /* If Touch the Screen */
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            rb.velocity = new Vector2(direction.x, direction.y) * charMovementSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }
        else
        {
            /* Move Char with same Speed as Camera */
            transform.Translate(0, CameraMovement.instace.speed * Time.deltaTime, 0);
        }
    }
}
