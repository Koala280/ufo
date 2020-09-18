using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instace;
    public float speed;
    void Start()
    {
        instace = this;
    }
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}