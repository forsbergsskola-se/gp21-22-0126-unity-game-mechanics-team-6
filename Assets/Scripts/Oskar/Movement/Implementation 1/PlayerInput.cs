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
            if (Input.GetKey(keyBinds.FlyUp))
                movementController.Fly();
            

            if (Input.GetKey(keyBinds.MoveLeft)) 
                movementController.MoveLeft();
            

            if (Input.GetKey(keyBinds.MoveRight))
                movementController.MoveRight();
        }
    }
}