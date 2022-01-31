using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class FlightSystem : MonoBehaviour
{
    public bool Fly;

    [SerializeField] private float maxFlightFuel = 150;
    [SerializeField] private float fuelUsagePerSecond = 60;
    [SerializeField] private float fuelRegenPerSecond = 100;
    [SerializeField] private int maxFuelRegenCooldown = 30;
    [SerializeField] private float upwardsBoostPerUpdate = 3;
    [SerializeField] private float maxFlightSpeed = 5;
    [SerializeField] private Rigidbody myRigidbody;

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
            Debug.Log($"Fuel level: {flightFuel}"); // TODO: Replace with ui element
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
            
            StartFuelRegenCooldown();
            
            BoostUpOnce();
        }
        else Debug.Log("Out of fuel"); // TODO: Replace with ui element
        
        Fly = false;
    }

    
    
    /// <summary>
    /// Regenerate fuel if not on cooldown.
    /// </summary>
    void RegenerateFuel()
    {
        if (fuelRegenCooldown > 0)
        {
            fuelRegenCooldown--;
            return;
        }
        
        FlightFuel += fuelRegenPerUpdate;
    }
    

    
    /// <summary>
    /// Start the cooldown to regenerating fuel.
    /// </summary>
    private void StartFuelRegenCooldown()
    {
        fuelRegenCooldown = maxFuelRegenCooldown;
    }

    
    
    /// <summary>
    /// Boost the character upwards once.
    /// </summary>
    void BoostUpOnce()
    {
        var currentVelocity = myRigidbody.velocity;

        // This limits our max flight speed upwards, without limiting the player itself to not fly up faster because of other reasons. Like a explosion or jump pad.
        var newYVelocity = currentVelocity.y > maxFlightSpeed
            ? currentVelocity.y
            : currentVelocity.y + upwardsBoostPerUpdate;

        myRigidbody.velocity = new Vector3(currentVelocity.x, newYVelocity, currentVelocity.z);
    }
}