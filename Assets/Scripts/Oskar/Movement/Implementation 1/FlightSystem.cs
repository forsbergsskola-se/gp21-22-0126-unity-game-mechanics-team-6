using UnityEngine;

namespace Oskar.Movement.Implementation1.Flight
{
    public class FlightSystem : MonoBehaviour
    {
        [HideInInspector] public bool Fly;
        public delegate void FuelLevelChanged(float newValue);
        public FuelLevelChanged OnFuelLevelChanged;
        public float maxFlightFuel = 150;
        public float fuelUsagePerSecond = 60;
        public float fuelRegenPerSecond = 100;
        public int maxFuelRegenCooldown = 30;
        public float upwardsBoostPerUpdate = 3;
        public float maxFlightSpeed = 5;
        
        [SerializeField] private Rigidbody myRigidbody;

        private float fuelUsagePerUpdate;
        private float fuelRegenPerUpdate;
        private float flightFuel;
        private int fuelRegenCooldown;
        

    
        /// <summary>
        /// Holds current fuel level.
        /// </summary>
        private float FlightFuel
        {
            get => flightFuel;
            set
            {
                flightFuel = Mathf.Clamp(value, 0, maxFlightFuel);
                OnFuelLevelChanged?.Invoke(flightFuel);
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
}