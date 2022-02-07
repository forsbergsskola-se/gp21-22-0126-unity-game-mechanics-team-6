using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash2 : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float speed = 5f;
    private float dashTime;
    public float startDashTime;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        var dashLeft = Input.GetKey(KeyCode.V);
        var dashRight = Input.GetKey(KeyCode.B);

        if (dashLeft)
            rigidbody.velocity = Vector3.left * speed;
        if (dashRight)
            rigidbody.velocity = Vector3.right * speed;
        
    }
}
