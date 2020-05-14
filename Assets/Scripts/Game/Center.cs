using UnityEngine;

public class Center : MonoBehaviour
{
    public static class Scale
    {
        public const float LARGE = 4.0f;
        public const float MEDIUM = 2.5f;
        public const float SMALL = 1.2f;
    }

    [SerializeField] private Orbit[] orbiters;
    
    void Start()
    {
        orbiters = FindObjectsOfType<Orbit>();
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
                
                foreach (var orbit in orbiters)
                {
                    if (orbit.transform.GetHashCode().Equals(hit.transform.GetHashCode()))
                    {
                        continue;
                    }
                    
                    Color color = orbit.gameObject.GetComponent<Renderer>().material.color;
                    color.a = 0;
                    orbit.gameObject.GetComponent<Renderer>().material.color = color;
                }
            }
        }
    }
}
