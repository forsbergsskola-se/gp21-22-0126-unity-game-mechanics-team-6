using UnityEngine;

public class CommandContainer : MonoBehaviour
{
    //These fields are visible in the inspector, which can be useful for testing.
    //But in some cases we might want to use [HideInInspector] or getters/setters to hide these fields.
    public float walkCommand;
    public bool jumpCommandDown;
    public bool jumpCommandUp;
    public bool jumpCommand;
}