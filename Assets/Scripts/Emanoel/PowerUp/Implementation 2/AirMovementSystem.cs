using UnityEngine;

namespace Oskar.Movement.Implementation2.Flight
{
    public class AirMovementSystem : MonoBehaviour
    {
        private Vector2 currentVelocity;

        [HideInInspector] public bool MoveUp;
        [HideInInspector] public bool MoveDown;
        [HideInInspector] public bool MoveLeft;
        [HideInInspector] public bool MoveRight;
    }
}