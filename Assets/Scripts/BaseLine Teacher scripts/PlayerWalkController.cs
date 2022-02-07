using UnityEngine;
using Team6.Toofan.Managers;

public class PlayerWalkController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private CommandContainer commandContainer;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float chargingMoveSpeedFactor = 0.5f;
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
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
        if (commandContainer.walkHorizontalCommand > 0 || commandContainer.walkHorizontalCommand < 0 
            || commandContainer.walkVerticalCommand > 0 || commandContainer.walkVerticalCommand < 0)
            animator.SetFloat(AnimationTags.SPEED, 0.5f);
        else
            animator.SetFloat(AnimationTags.SPEED, 0);



        myRigidbody.velocity = new Vector3(commandContainer.walkVerticalCommand * -currentMoveSpeed,
            0,
            commandContainer.walkHorizontalCommand * currentMoveSpeed);

        
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
