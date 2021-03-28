using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector2 screenBounds;
    private float asteroid_timer;
    public float weapon_timer;
    private Vector3 spawn_location;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        if (GameScript.instance.game_running)
        {
            if (asteroid_timer < 0)
            {
                SpawnItem("Asteroid");
                asteroid_timer = Random.Range(0.2f, 1.5f);
            }

            if (weapon_timer < 0)
            {
                SpawnItem("Weapon");
                weapon_timer = Random.Range(20.0f, 40.0f);
            }

            weapon_timer -= Time.deltaTime;
            asteroid_timer -= Time.deltaTime;
        }
        else
        {
            weapon_timer = 0;
            asteroid_timer = 0;
        }
    }

    private void SpawnItem(string tag)
    {
        spawn_location = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), 7, -7);
        GameObject item = ObjectPooler.instance.GetPooledObject(tag);
        if (item != null)
        {
            item.transform.position = spawn_location;
            item.transform.rotation = Quaternion.identity;
            item.SetActive(true);
        }
    }
}