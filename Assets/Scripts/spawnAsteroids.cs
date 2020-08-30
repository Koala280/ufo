using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAsteroids : MonoBehaviour
{
    public GameObject[] asteroidPrefab;
    private Vector2 screenBounds;

    void Start()
    {
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)]) as GameObject;
        a.transform.position = new Vector3(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2, -7);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
            yield return new WaitForSeconds(Random.Range(1, 7));
            spawnEnemy();
        }
    }
}