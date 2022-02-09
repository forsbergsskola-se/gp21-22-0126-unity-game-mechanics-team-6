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

    private bool isDead;
    public bool isPlayer;

    private void Awake()
    {
        animation = GetComponentInChildren<CharacterAnimation>();
        enemyMovement = GetComponent<EnemyAIMovement>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (isDead) return;

        health -= damage;
        if(health <= 0f)
        {
            animation.Dead();
            isDead = true;

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
}
