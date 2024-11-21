using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    void Update()

    {

        if (Input.GetMouseButtonDown(0)) // Check if left mouse button is pressed

        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Create a ray from mouse position

            RaycastHit hit;



            if (Physics.Raycast(ray, out hit)) // Check if ray hits anything

            {

                // Access information about the hit object

                GameObject objectHit = hit.collider.gameObject;

                Debug.Log("Player clicked on: " + objectHit.name);

            }

        }

    }
}
