using UnityEngine;

public class PlayerImmediateJumpController1 : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private CommandContainer1 commandContainer;
    [SerializeField] private GroundChecker1 groundChecker;
    [SerializeField] private float jumpForce = 500f;

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        //Apply jump force
        //Preferably interact with physics in FixedUpdate() 
        if (commandContainer.jumpCommandDown && groundChecker.IsGrounded)
            myRigidbody.AddForce(Vector3.up * jumpForce);
    }
}