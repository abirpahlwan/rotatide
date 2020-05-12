using System;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private float orbitSpeed = 1.0f;

    void Update()
    {
        // Orbit around parent
        transform.RotateAround(transform.parent.position, Vector3.down, orbitSpeed * Time.deltaTime);
    }
}
