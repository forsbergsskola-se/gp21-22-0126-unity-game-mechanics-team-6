using Oskar.Movement.Implementation1.Flight;
using Oskar.Movement.Implementation1.HorizontalMovement;
using UnityEngine;

namespace Oskar.Movement.Implementation1.Control
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private FlightSystem flightSystem;
        [SerializeField] private HorizontalMovementSystem horizontalMovementSystem;

        
        
        public void Fly() => flightSystem.Fly = true;
        public void MoveLeft() => horizontalMovementSystem.MoveLeft = true;
        public void MoveRight() => horizontalMovementSystem.MoveRight = true;
    }
}