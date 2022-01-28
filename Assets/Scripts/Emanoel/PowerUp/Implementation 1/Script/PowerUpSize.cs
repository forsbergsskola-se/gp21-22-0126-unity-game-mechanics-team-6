using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSize : MonoBehaviour
{
    public float multiplier = 1.4f;
    public float duration = 100f;
    
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
        player.transform.localScale *= multiplier;
        player.GetComponent<GroundChecker>().groundCheckLength *= multiplier;
        player.GetComponent<GroundChecker>().groundCheckRadius *= multiplier;
        
        //disable all visual for powerup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x amount of seconds
        yield return new WaitForSeconds(duration);
        
        //Reverse the effect on our player
        player.transform.localScale /= multiplier;
        player.GetComponent<GroundChecker>().groundCheckLength /= multiplier;
        player.GetComponent<GroundChecker>().groundCheckRadius /= multiplier;

        //Remove power up object
        Destroy(gameObject);
    }
}
