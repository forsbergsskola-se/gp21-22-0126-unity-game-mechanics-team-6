using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Rotate : MonoBehaviour
{
    private float randomNumber;
    private void Awake()
    {
        randomNumber = Random.Range(-30f, 30f);
    }
    private void Update()
    {
        this.transform.Rotate (new Vector3 (randomNumber, randomNumber, randomNumber) * Time.deltaTime * 3);
    }
}
