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

    private bool isDead;
    public bool isPlayer;

    private void Awake()
    {
        anim = GetComponentInChildren<CharacterAnimation>();
        enemyMovement = GetComponent<EnemyAIMovement>();
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
                    anim.KnockDown();
                    GetComponent<EnemyAIMovement>().attackPlayer = false;
                    //GetComponent<EnemyAIMovement>().enabled = false;
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

    private void EnemyDeath()
    {
        anim.Dead();
        isDead = true;
    }
}
