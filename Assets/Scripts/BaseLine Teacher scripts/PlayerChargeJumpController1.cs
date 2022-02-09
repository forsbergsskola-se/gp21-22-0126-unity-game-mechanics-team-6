using UnityEngine;

public class PlayerChargeJumpController1 : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private PlayerInputController1 playerInputController;
    [SerializeField] private GroundChecker1 groundChecker;
    [SerializeField] private float minimumJumpForce = 100f;
    [SerializeField] private float maximumJumpForce = 1000f;
    [SerializeField] private float chargeTime = 1f;

    private float jumpCharge;

    private void Update()
    {
        if (playerInputController.JumpInput)
            jumpCharge += Time.deltaTime / chargeTime;

        if (playerInputController.JumpInputUp)
        {
            var jumpForce = Mathf.Lerp(minimumJumpForce, maximumJumpForce, jumpCharge);
            jumpCharge = 0f;

            if (groundChecker.IsGrounded)
                myRigidbody.AddForce(Vector3.up * jumpForce);
        }
    }
}