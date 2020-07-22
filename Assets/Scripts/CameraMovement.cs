using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1f;
    void Update() {
       transform.Translate(0, speed * Time.deltaTime, 0);
    }
}