using System;
using System.Collections;
using System.Collections.Generic;
using Oskar.Movement.Implementation1.Control;
using UnityEngine;

public class PlayerChaseController : MonoBehaviour
{
    [SerializeField] private GameObject target;

    [SerializeField] private MovementController movementController;


    private IEnumerator chaseMethod;
    private bool chaseActive;

    private void Start()
    {
        chaseMethod = Chase();
    }


    private IEnumerator Chase()
    {
        chaseActive = true;

        yield return new WaitForSeconds(2);
        
        while (chaseActive)
        {
            Move();
        }
        yield break;
    }

    private void Update()
    {
        if (chaseActive)
            Move();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject != target) return;

        if (chaseActive)
        {
            chaseActive = false;
        }
        else
        {
            chaseActive = true;
        }
    }


    private void Move()
    {
        var currentPosition = transform.position;
        var targetPosition = target.transform.position;
        
        if (currentPosition.y < targetPosition.y)
            movementController.Fly();
            
        if (currentPosition.x > targetPosition.x)
            movementController.MoveLeft();
        if (currentPosition.x < targetPosition.x)
            movementController.MoveRight();
    }
}
