using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Team6.Toofan.Managers;

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

    public void Dead()
    {
        animator.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }

}
