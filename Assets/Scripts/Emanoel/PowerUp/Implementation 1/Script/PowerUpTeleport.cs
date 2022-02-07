using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTeleport : MonoBehaviour
{
    public int teleportations = 2;
    
    public GameObject pickupEffect;
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(Pickup(other));
    }
    IEnumerator Pickup(Collider player)
    {
        //spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply effect to the player
        player.GetComponent<PowerUpTeleportScript>().enabled = true;
        player.GetComponent<PowerUpTeleportScript>().teleportations = teleportations;
        
        //disable all visual for powerup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        
        yield return new WaitForSeconds(1);

        //Remove power up object
        Destroy(gameObject);
        
    }
}
