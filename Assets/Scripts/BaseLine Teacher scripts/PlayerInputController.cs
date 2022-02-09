using UnityEngine;
using Team6.Toofan.Managers;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] 
    private CommandContainer commandContainer;

    //Currently these fields are not accessed from other scripts. But I'll leave them public to show an example of public getter with private setter.
    public float walkInputHorizontal { get; private set; }
    public float walkInputVertical { get; private set; }
    public bool JumpInputDown { get; private set; }
    public bool JumpInputUp { get; private set; }
    public bool JumpInput { get; private set; }
    public bool AttackKickInput { get; private set; }
    public bool AttackHandInput { get; private set; }

    

    private void Update()
    {
        GetInput();
        SetCommands();
    }

    private void GetInput()
    {
        walkInputHorizontal = Input.GetAxis(Axis.HORIZONTAL_AXIS);
        walkInputVertical = Input.GetAxis(Axis.VERTICAL_AXIS);
        JumpInputDown = Input.GetKeyDown(KeyCode.Space);
        JumpInputUp = Input.GetKeyUp(KeyCode.Space);
        JumpInput = Input.GetKey(KeyCode.Space);
        AttackHandInput = Input.GetKeyDown(KeyCode.Z);
        AttackKickInput = Input.GetKeyDown(KeyCode.X);
    }

    private void SetCommands()
    {
        commandContainer.walkHorizontalCommand = walkInputHorizontal;
        commandContainer.walkVerticalCommand = walkInputVertical;
        commandContainer.jumpCommandDown = JumpInputDown;
        commandContainer.jumpCommandUp = JumpInputUp;
        commandContainer.jumpCommand = JumpInput;
        commandContainer.handAttackCommand = AttackHandInput;
        commandContainer.kickAttackCommand = AttackKickInput;
    }
}