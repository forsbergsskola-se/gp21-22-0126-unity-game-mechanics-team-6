using System.Collections;
using System.Collections.Generic;
using Team6.Toofan.Animations;
using Team6.Toofan.Managers;
using UnityEngine;

namespace Team6.Toofan.Fighting
{
    public class EnemyAIMovement : MonoBehaviour
    {
        private CharacterAnimation enemyAnim;

        private Rigidbody enemyBody;
        [SerializeField] float speed = 2.5f;
        [SerializeField] float attackRange = 0.4f;
        [SerializeField] float chasePlayerRange = 1f;

        float currentAttackTime;
        float defaultAttackTime = 2f;
        bool followPlayer;
        bool attackPlayer;

        Transform playerTarget;

        private void Awake()
        {
            enemyAnim = GetComponentInChildren<CharacterAnimation>();
            enemyBody = GetComponent<Rigidbody>();

            playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
        }
        // Start is called before the first frame update
        void Start()
        {
            followPlayer = true;
            currentAttackTime = defaultAttackTime;

        }

        // Update is called once per frame
        void Update()
        {
            FollowTarget();
            AttackTheTarget();
        }

        private void FixedUpdate()
        {
            
        }

        void FollowTarget()
        {
            if (!followPlayer)
                return;

            if (Vector3.Distance(transform.position, playerTarget.position) > attackRange)
            {
                transform.LookAt(playerTarget);
                enemyBody.velocity = transform.forward * speed;

                if (enemyBody.velocity.sqrMagnitude != 0)
                {
                    enemyAnim.Movement(1);
                }
            }
            else if (Vector3.Distance(transform.position, playerTarget.position) <= attackRange)
            {
                Debug.Log(Vector3.Distance(transform.position, playerTarget.position));
                enemyBody.velocity = Vector3.zero;
                enemyAnim.Movement(0);
                followPlayer = false;
                attackPlayer = true;
            }
        }

        void AttackTheTarget()
        {
            if (!attackPlayer) return;

            currentAttackTime += Time.deltaTime;

            if (currentAttackTime > defaultAttackTime)
            {
                enemyAnim.EnemyAttack(Random.Range(0, 3));
                currentAttackTime = 0;
            }
            if (Vector3.Distance(transform.position, playerTarget.position) > attackRange + chasePlayerRange)
            {
                attackPlayer = false;
                followPlayer = true;
            }
        }
    }
}
