using Oskar.Movement.Implementation1.Flight;
using UnityEngine;

namespace Oskar.Movement.Implementation1.Control
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private FlightSystem flightSystem;

        public void Fly()
        {
            flightSystem.Fly = true;
        }
    }
}