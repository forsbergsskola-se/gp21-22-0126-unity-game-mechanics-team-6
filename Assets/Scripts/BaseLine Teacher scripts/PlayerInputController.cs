using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] 
    private CommandContainer commandContainer;

    //Currently these fields are not accessed from other scripts. But I'll leave them public to show an example of public getter with private setter.
    public float WalkInput { get; private set; }
    public bool JumpInputDown { get; private set; }
    public bool JumpInputUp { get; private set; }
    public bool JumpInput { get; private set; }

    private void Update()
    {
        GetInput();
        SetCommands();
    }

    private void GetInput()
    {
        WalkInput = Input.GetAxis("Horizontal");
        JumpInputDown = Input.GetKeyDown(KeyCode.Space);
        JumpInputUp = Input.GetKeyUp(KeyCode.Space);
        JumpInput = Input.GetKey(KeyCode.Space);
    }

    private void SetCommands()
    {
        commandContainer.walkCommand = WalkInput;
        commandContainer.jumpCommandDown = JumpInputDown;
        commandContainer.jumpCommandUp = JumpInputUp;
        commandContainer.jumpCommand = JumpInput;
    }
}