using System;
using UnityEngine;

namespace Oskar.Movement.Implementation1.HorizontalMovement
{
    public class HorizontalMovementSystem : MonoBehaviour
    {
        public bool MoveLeft;
        public bool MoveRight;

        [SerializeField] private float maxHorizontalMovementSpeed;
        [SerializeField] private float horizontalVelocityPerSecond;
        [SerializeField] private Rigidbody myRigidbody;

        private float horizontalVelocityPerUpdate;


        private void Start()
        {
            horizontalVelocityPerUpdate = horizontalVelocityPerSecond / 60;
        }


        private void FixedUpdate()
        {
            if (!MoveLeft && !MoveRight)
                return;

            float currentSpeedModifier = 0;

            if (MoveLeft) currentSpeedModifier -= horizontalVelocityPerUpdate;
            if (MoveRight) currentSpeedModifier += horizontalVelocityPerUpdate;

            MoveLeft = false;
            MoveRight = false;
            
            ModifyVelocity(currentSpeedModifier);
            FlipCharacter(currentSpeedModifier);
        }



        private void ModifyVelocity(float horizontalModifier)
        {
            var velocity = myRigidbody.velocity;
            float newXVelocity = velocity.x;
            switch (horizontalModifier)
            {
                case 0:
                    return;
                case > 0:
                    if (velocity.x < maxHorizontalMovementSpeed)
                        newXVelocity += horizontalModifier;
                    break;
                case < 0:
                    if (velocity.x > maxHorizontalMovementSpeed * -1)
                        newXVelocity += horizontalModifier;
                    break;
            }
            
            velocity = new Vector3(newXVelocity, velocity.y, velocity.z);
            myRigidbody.velocity = velocity;
        }



        private void FlipCharacter(float horizontalModifier)
        {
            switch (horizontalModifier)
            {
                default:
                    return;
                case > 0:
                    SetLocalScale(1);
                    break;
                case < 0:
                    SetLocalScale(-1);
                    break;
            }
        }



        private void SetLocalScale(float xValue)
        {
            Debug.Log("Flipping character to " + xValue);
            var currentLocalScale = transform.localScale;
            transform.localScale = new Vector3(xValue, currentLocalScale.y, currentLocalScale.z);
        }
    }
}