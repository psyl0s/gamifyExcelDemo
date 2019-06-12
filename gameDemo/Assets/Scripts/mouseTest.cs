using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
