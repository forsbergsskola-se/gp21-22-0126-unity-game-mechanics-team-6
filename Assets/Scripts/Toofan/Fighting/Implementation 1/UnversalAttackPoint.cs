using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnversalAttackPoint : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer;
    public bool isEnemy;

    public GameObject hitFX;
   
    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }

    public void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if(hit.Length > 0)
        {
            print("Hit!" + hit[0].gameObject.name);

            gameObject.SetActive(false);
        }
    }
}
