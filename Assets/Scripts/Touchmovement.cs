using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchmovement : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float charMovementSpeed = 10f;
    public GameObject gameOverText, restartButton, mainMenuButton;


    // Start is called before the first frame update
    //use this for initialization
    private void Start()
    {
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        mainMenuButton.SetActive(false);
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        /* Increase Camera Movement Speed depending on y Position*/
        /* TODO ausm Update auslagern */
        GameObject mainCamera = GameObject.Find("Main Camera");
        CameraMovement cameraMovementScript = mainCamera.GetComponent<CameraMovement>();
        
        /* If Touch the Screen */
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0;
            direction = (touchPosition - transform.position);
            /* TODO FIX */
            cameraMovementScript.speed += direction.y / 50;
            rb.velocity = new Vector2(direction.x, direction.y) * charMovementSpeed;

            if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        } else {
            /* Move Char with same Speed as Camera */
            transform.Translate(0, cameraMovementScript.speed * Time.deltaTime, 0);
        }
    }

    /* Game Over if collide with Tag: Asteroid */
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag.Equals("Asteroid")) {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            mainMenuButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
