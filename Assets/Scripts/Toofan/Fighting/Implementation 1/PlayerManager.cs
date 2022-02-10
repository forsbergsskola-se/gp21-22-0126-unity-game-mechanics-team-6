using Oskar.Movement.Implementation1.Control;
using Oskar.Movement.Implementation1.Flight;
using Oskar.Movement.Implementation1.HorizontalMovement;
using System.Collections;
using System.Collections.Generic;
using Team6.Toofan.Managers;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;
    public SceneController sceneController;

    private void Awake()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        
        if(collision.gameObject.tag == Tags.VEHICLE_TAG)
        {
            collision.transform.parent = gameObject.transform;
            player.GetComponent<SkinnedMeshRenderer>().enabled = false;
            sceneController.NextScene();
        }
    }
}
