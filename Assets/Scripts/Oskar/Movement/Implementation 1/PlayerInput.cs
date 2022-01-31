using System;
using System.Collections;
using System.Collections.Generic;
using OpenCover.Framework.Model;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private MovementController movementController;
    private KeyBinds keyBinds;

    private void Start()
    {
        keyBinds = FindObjectOfType<KeyBinds>();
    }

    private void Update()
    {
        // Check player input.
        // Call correct movement system based on input

        if (Input.GetKey(keyBinds.FlyUp))
        {
            movementController.Fly();
        }
    }
}
