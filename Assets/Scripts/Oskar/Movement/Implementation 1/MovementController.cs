using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private FlightSystem flightSystem;

    public void Fly()
    {
        flightSystem.Fly = true;
    }
}
