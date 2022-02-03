using Oskar.Movement.Implementation2.Flight;
using UnityEngine;

namespace Oskar.Movement.Implementation2.Control
{
    public class MovementInputRelay : MonoBehaviour
    {
        [SerializeField] private AirMovementSystem airMovementSystem;

        public void MoveUp() => airMovementSystem.MoveUp = true;
        public void MoveDown() => airMovementSystem.MoveDown = true;
        public void MoveLeft() => airMovementSystem.MoveLeft = true;
        public void MoveRight() => airMovementSystem.MoveRight = true;
    }
}