using UnityEngine;

namespace Oskar.Movement.Implementation1.Control
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private MovementController movementController;
        private KeyBinds keyBinds;

        private void Start()
        {
            keyBinds = FindObjectOfType<KeyBinds>();
        }

        private void Update()
        {
            // Check player input.
            // Call correct movement system based on input

            if (Input.GetKey(keyBinds.FlyUp))
            {
                movementController.Fly();
            }
        }
    }
}