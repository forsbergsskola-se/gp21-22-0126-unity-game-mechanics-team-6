using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FlightSystem : MonoBehaviour
{
    public bool Fly;

    [SerializeField] private float maxFlightFuel;
    [SerializeField] private float fuelUsagePerSecond;
    [SerializeField] private float fuelRegenPerSecond;
    [SerializeField] private int maxFuelRegenCooldown;

    private float fuelUsagePerUpdate;
    private float fuelRegenPerUpdate;
    private float flightFuel;
    private int fuelRegenCooldown;
    
    
    private float FlightFuel
    {
        get => flightFuel;
        set
        {
            flightFuel = Mathf.Clamp(value, 0, maxFlightFuel);
            Debug.Log($"Fuel level: {flightFuel}");
        }
    }
    
    

    private void Start()
    {
        FlightFuel = maxFlightFuel;
        fuelRegenPerUpdate = fuelRegenPerSecond / 60;
        fuelUsagePerUpdate = fuelUsagePerSecond / 60;
    }
    
    
    
    private void FixedUpdate()
    {
        if (!Fly)
        {
            RegenerateFuel();
            return;
        }

        if (FlightFuel > fuelUsagePerUpdate)
        {
            FlightFuel -= fuelUsagePerUpdate;
            
            fuelRegenCooldown = maxFuelRegenCooldown;
            
            BoostUpOnce();
        }
        else Debug.Log("Out of fuel");
        
        Fly = false;
    }

    
    
    void BoostUpOnce()
    {
        // FlyHere
    }
    
    

    void RegenerateFuel()
    {
        if (fuelRegenCooldown > 0)
        {
            fuelRegenCooldown--;
            return;
        }
        
        FlightFuel += fuelRegenPerUpdate;
    }
}
