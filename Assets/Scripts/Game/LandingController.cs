using System;
using UnityEngine;

public class LandingController : MonoBehaviour
{
    public GameObject rocket;
    public GameObject planet;

    void OnEnable()
    {
        rocket = GameObject.FindWithTag("Player");
        planet = GameObject.FindWithTag("Planet").transform.parent.gameObject;
    }

    void OnDisable()
    {
        Destroy(rocket);
        Destroy(planet);
    }
}
