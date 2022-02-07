using Oskar.Movement.Implementation1.Flight;
using TMPro;
using UnityEngine;

namespace Oskar.Movement.Implementation1.Ui
{
    public class FuelText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fuelText;
        [SerializeField] private FlightSystem user;
        
        
        void Start()
        {
            // Subscribe to delegate.
            user.OnFuelLevelChanged += ChangeFuelText;
        }

        // Triggered whenever the fuel level changes.
        private void ChangeFuelText(float value)
        {
            fuelText.text = $"Fuel level: {Mathf.Round(value)}";
        }
    }
}