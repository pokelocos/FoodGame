using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private List<Component> components = new List<Component>();

    // Start is called before the first frame update
    void Start()
    {
        components = FindObjectsOfType<Component>().ToList();
       //components = FindObjectsOfType<Engine>().ToList<Component>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(components.Count);
            foreach (var e in components)
            {
                e.Active = !e.Active;
            }
        }

    }
}
