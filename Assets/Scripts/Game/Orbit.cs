using System;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    [SerializeField] private float orbitSpeed = 25.0f;

    void Update()
    {
        // Orbit around parent
        // transform.RotateAround(transform.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * (orbitSpeed * Time.deltaTime));
    }
}
