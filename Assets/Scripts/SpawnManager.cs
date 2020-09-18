using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector2 screenBounds;
    public GameObject[] asteroid_prefabs;
    private float asteroid_timer;

    void Update()
    {
        if (asteroid_timer < 0.0f)
        {
            spawnAsteroid();
            asteroid_timer = Random.Range(0.5f, 3.0f);
        }
    
        asteroid_timer -= Time.deltaTime;
    }
    
    private void spawnAsteroid()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject asteroid = Instantiate(asteroid_prefabs[Random.Range(0, asteroid_prefabs.Length)]) as GameObject;
        asteroid.transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y + 8, -7);
    }
}