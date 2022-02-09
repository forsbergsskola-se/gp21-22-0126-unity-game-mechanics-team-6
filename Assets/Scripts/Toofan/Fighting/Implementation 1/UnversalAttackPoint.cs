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

    public GameObject hitFXPrefab;
   
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
           
            if (isPlayer)
            {
                var hitFxPos = hit[0].transform.position;
                hitFxPos.y += 1.3f;

                if(hit[0].transform.forward.x > 0)
                {
                    hitFxPos.x += 0.3f;
                }else if(hit[0].transform.forward.x < 0)
                {
                    hitFxPos.x -= 0.3f; 
                }
                Instantiate(hitFXPrefab, hitFxPos, Quaternion.identity);
            }
            gameObject.SetActive(false);
            
        }
    }
}
