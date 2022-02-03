using System;
using UnityEngine;

namespace Oskar.Movement.Implementation2.Flight
{
    /// <summary>
    /// I HATE this code. It is so horrible. Moving the object by teleporting it with transform position? Horrible. But
    /// having so little time I had to just throw this together. To anyone who sees this, I am sorry.
    ///
    /// The entire movement is buggy. It randomly moves on it's own. It teleports through the ground. It stutters. Bad.
    /// </summary>
    public class AirMovementSystem : MonoBehaviour
    {
        private Vector3 currentVelocity;
        
        // I could make this more nice looking, but with the time constraints I rather make a quick functional solution
        // than a good looking one.
        public bool MoveUp;
        public bool MoveDown;
        public bool MoveLeft;
        public bool MoveRight;

        [SerializeField] private float horizontalAcceleration;
        [SerializeField] private float verticalAcceleration;

        [SerializeField] private float maxHorizontalSpeedPerSecond;
        [SerializeField] private float maxVerticalSpeedPerSecond;
        
        
        private float maxHorizontalSpeedPerUpdate;
        private float maxVerticalSpeedPerUpdate;


        private void Start()
        {
            maxHorizontalSpeedPerUpdate = maxHorizontalSpeedPerSecond * Time.fixedDeltaTime;
            maxVerticalSpeedPerUpdate = maxVerticalSpeedPerSecond * Time.fixedDeltaTime;
        }


        private void FixedUpdate()
        {
            var x = currentVelocity.x;
            var y = currentVelocity.y;

            if (MoveUp)
                y += verticalAcceleration;
            else if (y > 0)
                y = Mathf.Max(y - verticalAcceleration, 0);
            

            if (MoveDown)
                y -= verticalAcceleration;
            else if (y < 0)
                y = Mathf.Min(y + verticalAcceleration, 0);
            

            if (MoveLeft)
                x -= horizontalAcceleration;
            else if (x < 0)
                x = Mathf.Min(x + horizontalAcceleration, 0);

            if (MoveRight)
                x += horizontalAcceleration;
            else if (x > 0)
                x = Mathf.Max(x - horizontalAcceleration, 0);
            
            
            MoveUp = false;
            MoveDown = false;
            MoveLeft = false;
            MoveRight = false;



            currentVelocity = new Vector3(Mathf.Clamp(x, -maxHorizontalSpeedPerUpdate, maxHorizontalSpeedPerUpdate),
                Mathf.Clamp(y, -maxVerticalSpeedPerUpdate, maxVerticalSpeedPerUpdate));

            Debug.Log(currentVelocity);
            transform.position += currentVelocity;
        }
    }
}