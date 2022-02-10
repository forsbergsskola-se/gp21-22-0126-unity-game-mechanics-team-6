using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour
{
   public Rigidbody _rb;
    public float moveSpeed = 5f;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    private void Update()
    {
        //movement input vertical and horizontally
        var horInput = Input.GetAxis("Horizontal");
        var vertInput = Input.GetAxis("Vertical");
        //Set move velocity
        _rb.velocity = new Vector3(horInput * moveSpeed, _rb.velocity.y, vertInput * moveSpeed);
        
        //Checking if dashing, if not, then checking if currently pressing dash input(V)
        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Assigning direction no. to each input direction
                if (horInput < 0)
                {
                    direction = 1;
                }
                else if (horInput > 0)
                {
                    direction = 2;
                }
                else if (vertInput < 0)
                {
                    direction = 3;
                }
                else if (vertInput > 0)
                {
                    direction = 4;
                }
            }
        }
        else
        {
            //"Resetting" dash values at the end of dash/before start of dash
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                _rb.velocity = Vector3.zero;
            }
            else
            {
                //Setting dashtime to decrease slowly over time
                dashTime -= Time.deltaTime;
                //Adding velocity to each dash direction
                if (direction == 1)
                {
                    _rb.velocity = Vector3.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    _rb.velocity = Vector3.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    _rb.velocity = Vector3.back * dashSpeed;
                }
                else if (direction == 4)
                {
                    _rb.velocity = Vector3.forward * dashSpeed;
                }
            }
        }
    }
}

