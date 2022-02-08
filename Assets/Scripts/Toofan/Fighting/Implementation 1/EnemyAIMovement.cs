using System.Collections;
using System.Collections.Generic;
using Team6.Toofan.Animations;
using Team6.Toofan.Managers;
using UnityEngine;

public class EnemyAIMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;

    private Rigidbody rigidbody;
    [SerializeField] float speed = 2.5f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] float chasePlayerRange = 1f;

    float currentAttackTime;
    float defaultAttackTime = 2f;
    bool followPlayer;
    bool attackPlayer;

    Transform playerTarget;

    private void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        rigidbody = GetComponent<Rigidbody>();

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
    }

    void FollowTarget()
    {
        if (!followPlayer)
            return;
        if(Vector3.Distance(transform.position, playerTarget.position) > attackRange)
        {
            transform.LookAt(playerTarget);
            rigidbody.velocity = transform.forward * speed;

            if(rigidbody.velocity.sqrMagnitude != 0)
            {

            }
        }
    }
}
