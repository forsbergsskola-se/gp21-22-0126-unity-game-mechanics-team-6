using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTeleportScript : MonoBehaviour
{
    Vector3 newPosition;

    private void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        // Check if you click the left mouse button then change position
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
                transform.position = newPosition;
            }

        }
    }
}
