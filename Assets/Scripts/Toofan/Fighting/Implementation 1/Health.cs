using System.Collections;
using System.Collections.Generic;
using Team6.Toofan.Animations;
using Team6.Toofan.Fighting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimation anim;
    private EnemyAIMovement enemyMovement;

    public bool isDead;
    public bool isPlayer;
    
    public Collider capsuleCollider;
    public Collider[] allColiders;
    private void Awake()
    {
        anim = GetComponentInChildren<CharacterAnimation>();
        enemyMovement = GetComponent<EnemyAIMovement>();
        capsuleCollider = GetComponent<Collider>();
        allColiders = GetComponentsInChildren<Collider>();
        GoRagDoll(false);
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (isDead) return;

        health -= damage;
        if(health <= 0f)
        {
            isDead = true;
            GoRagDoll(true);
            if (isPlayer)
            {

            }
            return;
        }

        if (!isPlayer)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    anim.KnockDown();

                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    anim.GetHit();
                }
            }
        }
    }

    
   

   
    public void GoRagDoll(bool isRagdoll)
    {
        foreach (var col in allColiders)
        {
            col.enabled = isRagdoll;
            capsuleCollider.enabled = !isRagdoll;
            GetComponent<Rigidbody>().useGravity = !isRagdoll;
            GetComponentInChildren<Animator>().enabled = !isRagdoll;
        }
    }
}
