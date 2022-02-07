using UnityEngine;

namespace Oskar.Movement.Implementation2.Ai
{
    public class TargetSender : MonoBehaviour
    {
        [SerializeField] private AiMovementController[] aiMovementControllers;
        [SerializeField] private float minRange;

        private void FixedUpdate()
        {
            for (int i = 0; i < aiMovementControllers.Length; i++)
            {
                aiMovementControllers[i].TargetPosition = CalculateTarget(i);
            }
            //
            // aiMovementController.TargetPosition = CalculateTarget();
        }

        private Vector3 CalculateTarget(int aiIndex)
        {
            var thisPosition = transform.position;
            var aiPosition = aiMovementControllers[aiIndex].transform.position;
            
            // Get the difference between them.
            var difference = thisPosition - aiPosition;
            
            // Normalize
            var normal = difference.normalized;
            
            // Add the normalized vector times minDistance to the player position to get the target.
            var result = thisPosition - normal * minRange;

            return result;
        }
    }
}