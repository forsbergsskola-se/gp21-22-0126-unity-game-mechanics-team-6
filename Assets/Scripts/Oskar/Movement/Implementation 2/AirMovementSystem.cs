using UnityEngine;

namespace Oskar.Movement.Implementation2.Flight
{
    public class AirMovementSystem : MonoBehaviour
    {
        private Vector3 currentVelocity;
        
        // I could make this more nice looking, but with the time constraints I rather make a quick functional solution
        // than a good looking one.
        [HideInInspector] public bool MoveLeft;
        [HideInInspector] public bool MoveRight;
        [HideInInspector] public bool MoveUp;
        [HideInInspector] public bool MoveDown;
        
        [SerializeField] private float horizontalAcceleration = 3;
        [SerializeField] private float verticalAcceleration = 3;
        [SerializeField] private float maxHorizontalSpeedPerSecond = 500;
        [SerializeField] private float maxVerticalSpeedPerSecond = 500;
        [SerializeField] private Rigidbody myRigidBody;
        
        private float maxHorizontalSpeedPerUpdate;
        private float maxVerticalSpeedPerUpdate;


        
        private void Start()
        {
            maxHorizontalSpeedPerUpdate = maxHorizontalSpeedPerSecond * Time.fixedDeltaTime;
            maxVerticalSpeedPerUpdate = maxVerticalSpeedPerSecond * Time.fixedDeltaTime;
        }

        

        private void FixedUpdate()
        {
            var velocity = myRigidBody.velocity;
            var newX = velocity.x;
            var newY = velocity.y;

            newX = ModifyX(newX);
            newY = ModifyY(newY);

            myRigidBody.velocity = new Vector3(newX, newY, velocity.z);
            
            ResetBooleans();
        }

        
        /// <summary>
        /// Reset control booleans to false.
        /// </summary>
        private void ResetBooleans()
        {
            MoveUp = false;
            MoveDown = false;
            MoveLeft = false;
            MoveRight = false;
        }
        
        
        
        /// <summary>
        /// Modify x velocity.
        /// </summary>
        /// <param name="newX"></param>
        /// <returns></returns>
        private float ModifyX(float newX)
        {
            if (!(MoveLeft && MoveRight))
            {
                if (MoveLeft)
                    if (newX > -maxHorizontalSpeedPerUpdate)
                        newX -= horizontalAcceleration;
                if (MoveRight)
                    if (newX < maxHorizontalSpeedPerUpdate)
                        newX += horizontalAcceleration;
            }

            return newX;
        }

        
        
        /// <summary>
        /// Modify y velocity.
        /// </summary>
        /// <param name="newY"></param>
        /// <returns></returns>
        private float ModifyY(float newY)
        {
            if (!(MoveUp && MoveDown))
            {
                if (MoveUp)
                    if (newY < maxVerticalSpeedPerUpdate)
                        newY += verticalAcceleration;
                if (MoveDown)
                    if (newY > -maxVerticalSpeedPerUpdate)
                        newY -= verticalAcceleration;
            }

            return newY;
        }
    }
}