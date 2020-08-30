using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float respawnTime = 1f;
    private float cd_Raygun = 0;

    void Update() {
        if (cd_Raygun > 0)
        {
            cd_Raygun -= Time.deltaTime;
        }
    }

    public bool Pickup(GameObject obj) {
        switch (obj.tag)
        {
            case "Weapon":
            return true;

            default:
            Debug.LogWarning($"WARNING: no Handler implemented for object Tag: {obj.tag}!!!");
            return false;
        }
    }

    public void PickedUp(GameObject obj) {
        switch (obj.name)
        {
            case "Raygun":
                cd_Raygun = 15;
                InvokeRepeating("LaunchProjectile", 1.0f, 1.0f);
            break;

            default:
            Debug.LogWarning($"WARNING: no Handler implemented for object Tag: {obj.tag}!!!");
            break;
        }
    }

    private void LaunchProjectile()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if (cd_Raygun <= 0)
        {
            CancelInvoke("LaunchProjectile");
        }
    }
}
