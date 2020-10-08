using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPicked : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        player.GetComponent<PolygonCollider2D>().enabled = false;
    }
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1);
        transform.Rotate(0, 0, 13);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Asteroid"))
        {
            Score.instance.score_value += 500;
            Destroy(col.gameObject);
        }
    }

    void OnDestroy()
    {
        player.GetComponent<PolygonCollider2D>().enabled = true;
    }
}
