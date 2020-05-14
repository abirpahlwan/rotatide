using UnityEngine;

public class OrbitController : MonoBehaviour
{
    public static class Scale
    {
        public const float LARGE = 4.0f;
        public const float MEDIUM = 2.5f;
        public const float SMALL = 1.2f;
    }

    [SerializeField] private Orbit[] orbits;
    
    void Start()
    {
        // orbiters = GetComponentsInChildren<Orbit>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                // TODO Compare Tag with planet
                // TODO Lerp position
                // TODO Lerp scale
                // TODO Lerp alpha
                hit.transform.position = Vector3.zero;
                
                foreach (var orbiter in orbits)
                {
                    if (orbiter.transform.GetHashCode().Equals(hit.transform.GetHashCode()))
                    {
                        continue;
                    }
                    
                    Color color = orbiter.gameObject.GetComponent<Renderer>().material.color;
                    color.a = 0;
                    orbiter.gameObject.GetComponent<Renderer>().material.color = color;
                    orbiter.gameObject.SetActive(false);
                }
            }
        }
    }
}
