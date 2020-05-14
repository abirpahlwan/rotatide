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
        orbits = GetComponentsInChildren<Orbit>();
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
                hit.transform.parent.parent = null;
                hit.transform.parent.position = Vector3.zero;
                DontDestroyOnLoad(hit.transform.parent);
                
                hit.transform.position = Vector3.zero;
                
                // Hide other planets
                foreach (var orbiter in orbits)
                {
                    if (orbiter.transform.GetChild(0).GetHashCode().Equals(hit.transform.GetHashCode()))
                    {
                        continue;
                    }
                    
                    Color color = orbiter.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
                    color.a = 0;
                    orbiter.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = color;
                    orbiter.transform.GetChild(0).gameObject.SetActive(false);
                    
                }
                
                // Load next scene
                GameManager.Instance.LoadScene("Land");
            }
        }
    }
}
