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

        public Vector3 TargetPosition;


        private void FixedUpdate()
        {
            var currentPosition = transform.position;

            if (TargetPosition.x > currentPosition.x)
                movementInputRelay.MoveLeft();
            else if (TargetPosition.x < currentPosition.x)
                movementInputRelay.MoveRight();
            
            if (TargetPosition.y > currentPosition.y)
                movementInputRelay.MoveUp();
            else if (TargetPosition.y < currentPosition.y)
                movementInputRelay.MoveDown();
        }
    }
}