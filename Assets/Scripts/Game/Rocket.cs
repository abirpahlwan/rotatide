using System;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float startTime;
    private float journeyLength;
    
    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, Vector3.zero);
    }
    
    void Update()
    {
        float distCovered = (Time.time - startTime);
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(transform.position, Vector3.zero, fractionOfJourney);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag.Equals("Planet"))
        {
            Debug.Log("Game Over");
        }
    }
}
