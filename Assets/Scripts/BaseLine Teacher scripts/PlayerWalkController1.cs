using UnityEngine;
using Team6.Toofan.Managers;
using Team6.Toofan.Animations;

public class PlayerWalkController1 : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private CommandContainer1 commandContainer;
    [SerializeField] private GroundChecker1 groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float chargingMoveSpeedFactor = 0.5f;
    CharacterAnimation characterAnim;
    

    private void Awake()
    {
        characterAnim = GetComponentInChildren<CharacterAnimation>();
    }

    private void Update()
    {
        HandleWalking();
        HandleRotation();
    }

    private void HandleWalking()
    {
        //Slower move speed while charging a jump.
        var currentMoveSpeed = moveSpeed;
        if (commandContainer.jumpCommand && groundChecker.IsGrounded)
            currentMoveSpeed *= chargingMoveSpeedFactor;
        

        myRigidbody.velocity = new Vector3(commandContainer.walkVerticalCommand * -currentMoveSpeed,
                0,
                commandContainer.walkHorizontalCommand * currentMoveSpeed);
        AnimateMovement();

    }

    private void AnimateMovement()
    {
        if (myRigidbody.velocity.sqrMagnitude != 0)
            characterAnim.Movement(0.5f);
        else
            characterAnim.Movement(0);
    }

    private void HandleRotation()
    {
        if (commandContainer.walkVerticalCommand > 0)
            transform.rotation = Quaternion.Euler(0, -Mathf.Abs(90f), 0);
        else if (commandContainer.walkVerticalCommand < 0)
            transform.rotation = Quaternion.Euler(0, Mathf.Abs(90f), 0);
        else if(commandContainer.walkHorizontalCommand > 0)
            transform.rotation = Quaternion.Euler(0, Mathf.Abs(0), 0);
        else if (commandContainer.walkHorizontalCommand < 0)
            transform.rotation = Quaternion.Euler(0, -Mathf.Abs(180f), 0);

    }
}
