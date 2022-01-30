using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMoveSpeed : MonoBehaviour
{
    public float multiplier = 1.4f;
    [Tooltip("0 = Forever, otherwise in seconds")]
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
        player.GetComponent<PlayerWalkController>().moveSpeed *= multiplier;
        
        //disable all visual for powerup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        //Wait x amount of seconds, if 0 then forever.
        if (duration == 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(duration);
            
            //Reverse the effect on our player
            player.GetComponent<PlayerWalkController>().moveSpeed /= multiplier;
            
            //Remove power up object
            Destroy(gameObject);
        }
    }
}
