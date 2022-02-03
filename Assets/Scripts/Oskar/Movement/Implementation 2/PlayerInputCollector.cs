using UnityEngine;

namespace Oskar.Movement.Implementation2.Control
{
    public class PlayerInputCollector : MonoBehaviour
    {
        [SerializeField] private MovementInputRelay movementInputRelay;
        [SerializeField] private InputKeys inputKeys;

        private void Update()
        {
            if (Input.GetKey(inputKeys.MoveLeft))
                movementInputRelay.MoveLeft();
            if (Input.GetKey(inputKeys.MoveRight))
                movementInputRelay.MoveRight();
            if (Input.GetKey(inputKeys.MoveUp))
                movementInputRelay.MoveUp();
            if (Input.GetKey(inputKeys.MoveDown))
                movementInputRelay.MoveDown();
        }
    }
}