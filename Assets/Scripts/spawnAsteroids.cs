using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour
{
    public GameObject[] asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    void Start()
    {
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)]) as GameObject;
        a.transform.position = new Vector3(Random.Range(-screenBounds.x * 2, screenBounds.x * 2), screenBounds.y * 2, -3);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}