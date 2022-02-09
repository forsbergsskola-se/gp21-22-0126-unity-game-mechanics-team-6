using System.Collections;
using System.Collections.Generic;
using Team6.Toofan.Animations;
using Team6.Toofan.Fighting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    private CharacterAnimation animation;
    private EnemyAIMovement enemyMovement;
    private Collider mainCollider;
    private Collider[] allColliders;
    private Rigidbody rb;

    private bool isDead;
    public bool isPlayer;

    private void Awake()
    {
        animation = GetComponentInChildren<CharacterAnimation>();
        enemyMovement = GetComponent<EnemyAIMovement>();
        mainCollider = GetComponent<Collider>();
        allColliders = GetComponentsInChildren<Collider>(true);
        rb = GetComponent<Rigidbody>();
        
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (isDead) return;

        health -= damage;
        if(health <= 0f)
        {
            EnemyDeath();

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
                    animation.KnockDown();
                }
            }
            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animation.GetHit();
                }
            }
        }
    }

    public void DoRagdoll(bool isRagdoll)
    {
        foreach (var col in allColliders)
        {
            col.enabled = isRagdoll;
            mainCollider.enabled = !isRagdoll;
            rb.useGravity = !isRagdoll;
            GetComponentInChildren<Animator>().enabled = !isRagdoll;
        }
    }
    void EnemyDeath()
    {
        animation.Dead();
        rb.AddForce(-Vector3.forward * 0.3f);
        isDead = true;
        DoRagdoll(true);
        GetComponent<EnemyAIMovement>().enabled = false;
    }
}
