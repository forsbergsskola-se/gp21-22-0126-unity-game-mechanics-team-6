using System.Collections;
using System.Collections.Generic;
using Oskar.Movement.Implementation1.HorizontalMovement;
using Oskar.Movement.Implementation2.Flight;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (other.CompareTag("Enemy"))
            StartCoroutine(PickupEnemy(other));
    }
    IEnumerator PickupEnemy(Collider enemy)
    {
        //spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply effect to the player
        if(enemy.GetComponent<HorizontalMovementSystem>() != null)
            enemy.GetComponent<HorizontalMovementSystem>().maxHorizontalMovementSpeed /= multiplier;

        if (enemy.GetComponent<AirMovementSystem>() != null)
            enemy.GetComponent<AirMovementSystem>().horizontalAcceleration /= multiplier;
        
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
            if(enemy.GetComponent<HorizontalMovementSystem>() != null)
                enemy.GetComponent<HorizontalMovementSystem>().maxHorizontalMovementSpeed *= multiplier;
            
            if (enemy.GetComponent<AirMovementSystem>() != null)
                enemy.GetComponent<AirMovementSystem>().horizontalAcceleration *= multiplier;
            
            //Remove power up object
            Destroy(gameObject);
        }
    }
    IEnumerator Pickup(Collider player)
    {
        //spawn a cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply effect to the player
        if(player.GetComponent<HorizontalMovementSystem>() != null)
            player.GetComponent<HorizontalMovementSystem>().maxHorizontalMovementSpeed *= multiplier;

        if (player.GetComponent<AirMovementSystem>() != null)
            player.GetComponent<AirMovementSystem>().horizontalAcceleration *= multiplier;
        
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
            if(player.GetComponent<HorizontalMovementSystem>() != null)
                player.GetComponent<HorizontalMovementSystem>().maxHorizontalMovementSpeed /= multiplier;
            
            if (player.GetComponent<AirMovementSystem>() != null)
                player.GetComponent<AirMovementSystem>().horizontalAcceleration /= multiplier;
            
            //Remove power up object
            Destroy(gameObject);
        }
    }
}
