using UnityEngine;

namespace Oskar.Movement.Implementation1.HorizontalMovement
{
    public class HorizontalMovementSystem : MonoBehaviour
    {
        [HideInInspector] public bool MoveLeft;
        [HideInInspector] public bool MoveRight;

        [SerializeField] private float maxHorizontalMovementSpeed = 4;
        [SerializeField] private float horizontalVelocityPerSecond = 50;
        [SerializeField] private Rigidbody myRigidbody;

        private float horizontalVelocityPerUpdate;

        private const float FacingRight = 1;
        private const float FacingLeft = -1;

        

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



        /// <summary>
        /// Modify the velocity of the object. Takes max speed into account.
        /// </summary>
        /// <param name="horizontalModifier">speed modifier</param>
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



        /// <summary>
        /// Flip the character based on x velocity.
        /// </summary>
        /// <param name="horizontalModifier"></param>
        private void FlipCharacter(float horizontalModifier)
        {
            switch (horizontalModifier) 
            {
                case > 0:
                    SetDirection(FacingRight);
                    break;
                case < 0:
                    SetDirection(FacingLeft);
                    break;
            }
        }

        
        
        /// <summary>
        /// Sets direction by changing the local scale. Input 1 to face right, -1 to face left.
        /// </summary>
        /// <param name="direction">Direction to face</param>
        private void SetDirection(float direction)
        {
            var currentLocalScale = transform.localScale;
            transform.localScale = new Vector3(direction, currentLocalScale.y, currentLocalScale.z);
        }
    }
}