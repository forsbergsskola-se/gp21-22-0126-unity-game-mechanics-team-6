using System;
using System.Collections;
using System.Collections.Generic;
using Oskar.Movement.Implementation2.Control;
using UnityEngine;

namespace Oskar.Movement.Implementation2.Ai
{
    public class AiMovementController : MonoBehaviour
    {
        public MovementInputRelay movementInputRelay;

        [HideInInspector] public Vector3 TargetPosition;

        private const float deadZone = 0.5f; 

        private void FixedUpdate()
        {
            var currentPosition = transform.position;

            if (TargetPosition.x < currentPosition.x - deadZone)
                movementInputRelay.MoveLeft();
            else if (TargetPosition.x > currentPosition.x + deadZone)
                movementInputRelay.MoveRight();
            
            if (TargetPosition.y > currentPosition.y + deadZone)
                movementInputRelay.MoveUp();
            else if (TargetPosition.y < currentPosition.y - deadZone)
                movementInputRelay.MoveDown();
        }
    }
}