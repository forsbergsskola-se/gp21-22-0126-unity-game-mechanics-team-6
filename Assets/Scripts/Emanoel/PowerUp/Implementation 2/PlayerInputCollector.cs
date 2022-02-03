using UnityEngine;

namespace Oskar.Movement.Implementation2.Control
{
    public class PlayerInputCollector : MonoBehaviour
    {
        [SerializeField] private MovmentInputRelay movmentInputRelay;
        [SerializeField] private InputKeys inputKeys;

        private void Update()
        {
            if (Input.GetKey(inputKeys.MoveUp))
                movmentInputRelay.MoveUp();
            if (Input.GetKey(inputKeys.MoveDown))
                movmentInputRelay.MoveDown();
            if (Input.GetKey(inputKeys.MoveLeft))
                movmentInputRelay.MoveLeft();
            if (Input.GetKey(inputKeys.MoveRight))
                movmentInputRelay.MoveRight();
        }
    }
}