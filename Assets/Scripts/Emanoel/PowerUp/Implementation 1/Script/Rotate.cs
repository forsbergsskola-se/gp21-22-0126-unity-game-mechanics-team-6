using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private void Update()
    {
        this.transform.Rotate (new Vector3 (30, 30, 30) * Time.deltaTime * 3);
    }
}
