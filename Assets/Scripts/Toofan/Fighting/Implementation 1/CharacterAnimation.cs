using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Team6.Toofan.Managers;

namespace Team6.Toofan.Animations
{
    public class CharacterAnimation : MonoBehaviour
    {
        Animator animator;
        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Movement(float value)
        {
            animator.SetFloat(AnimationTags.SPEED, value);
        }

        public void PunchRight()
        {
            animator.SetTrigger(AnimationTags.BOXINGRIGHT_TRIGGER);
        }

        public void PunchLeft()
        {
            animator.SetTrigger(AnimationTags.BOXINGLEFT_TRIGGER);
        }

        public void HighKick()
        {
            animator.SetTrigger(AnimationTags.HIGHKICK_TRIGGER);
        }

        public void ElbowPunch()
        {
            animator.SetTrigger(AnimationTags.ELBOWPUNCH_TRIGGER);
        }

        public void KneeKick()
        {
            animator.SetTrigger(AnimationTags.KNEEKICK_TRIGGER);
        }

        public void FlyingKick()
        {
            animator.SetTrigger(AnimationTags.FLYINGKICK_TRIGGER);
        }

        public void Dead()
        {
            animator.SetTrigger(AnimationTags.DEAD_TRIGGER);
        }

        public void EnemyAttack(int attack)
        {
            if (attack == 0)
                animator.SetTrigger(AnimationTags.BOXINGRIGHT_TRIGGER);
            if (attack == 1)
                animator.SetTrigger(AnimationTags.BOXINGLEFT_TRIGGER);
            if (attack == 2)
                animator.SetTrigger(AnimationTags.HIGHKICK_TRIGGER);
        }

        public void KnockDown()
        {
            animator.SetTrigger(AnimationTags.KNOCKDOWN_TRIGGER);
        }

        public void GetHit()
        {
            animator.SetTrigger(AnimationTags.HIT_TRIGGER);
        }

        public void StandUp()
        {
            animator.SetTrigger(AnimationTags.STANDUP_TRIGGER);
        }
    }
}
