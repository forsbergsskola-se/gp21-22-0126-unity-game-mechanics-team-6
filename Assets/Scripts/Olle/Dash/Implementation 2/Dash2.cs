using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash2 : MonoBehaviour
{
    public float dashPower = 100f;
    public float chargedPower = 0;
    public Rigidbody rigidbody;
    private bool releaseDash = false;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        //While holding V or B, charge power
        if (Input.GetKey(KeyCode.V) || Input.GetKey(KeyCode.B))
        {
            chargedPower += Time.deltaTime;
        }
        
        var dashChargeRight = Input.GetKeyDown(KeyCode.V);
        var dashChargeLeft = Input.GetKeyDown(KeyCode.B);
        
        var dashLeft = Input.GetKeyUp(KeyCode.V);
        var dashRight = Input.GetKeyUp(KeyCode.B);
        //release charge to the left
        if (dashLeft)
        {
            releaseDash = true;
            rigidbody.velocity = Vector3.left * chargedPower * dashPower;
            releaseDash = false;
            chargedPower = 0;
        }
        //release charge to the right
        if (dashRight)
        {
            releaseDash = true;
            rigidbody.velocity = Vector3.right * chargedPower * dashPower;
            releaseDash = false;
            chargedPower = 0;
        }
    }
}
