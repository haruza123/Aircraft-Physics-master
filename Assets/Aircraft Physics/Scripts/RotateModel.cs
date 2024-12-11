using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour
{
    public float rotationSpeed = 30f; // Kecepatan rotasi

    void Update()
    {
        // Rotasi model pada sumbu Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}

