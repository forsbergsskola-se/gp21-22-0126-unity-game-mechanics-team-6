using System.Collections;
using System.Collections.Generic;
using Team6.Toofan.Animations;
using UnityEngine;

namespace Team6.Toofan.Fighting
{
    public class PlayerAttack : MonoBehaviour
    {
        private CommandContainer commandContainer;
        private CharacterAnimation characterAnimation;
        bool isTimeToRest;
        float defaultComboTime = 0.4f;
        float currentComboTime;

        private ComboStates currentComboState;

        void Start()
        {
            commandContainer = GetComponentInChildren<CommandContainer>();
            characterAnimation = GetComponentInChildren<CharacterAnimation>();

            currentComboState = ComboStates.None;
            currentComboTime = defaultComboTime;
        }


        void Update()
        {
            Attack();
            ResetComboStates();
        }

        public void Attack()
        {
            ComboAttacks();

        }

        public void ComboAttacks()
        {
            if (commandContainer.handAttackCommand)
            {
                if (currentComboState == ComboStates.ElbowAttack ||
                    currentComboState == ComboStates.HighKick ||
                    currentComboState == ComboStates.KneeKick)
                    return;
                currentComboState++;
                isTimeToRest = true;
                currentComboTime = defaultComboTime;
                if (currentComboState == ComboStates.PunchLeft)
                {
                    characterAnimation.PunchLeft();
                }
                if (currentComboState == ComboStates.PunchRight)
                {
                    characterAnimation.PunchRight();
                }
                if (currentComboState == ComboStates.ElbowAttack)
                {
                    characterAnimation.ElbowPunch();
                }
            }

            if (commandContainer.kickAttackCommand)
            {
                if (currentComboState == ComboStates.ElbowAttack ||
                currentComboState == ComboStates.KneeKick)
                    return;
                if (currentComboState == ComboStates.None ||
                currentComboState == ComboStates.PunchRight ||
                currentComboState == ComboStates.PunchLeft)
                    currentComboState = ComboStates.HighKick;
                else if (currentComboState == ComboStates.HighKick)
                    currentComboState++;
                isTimeToRest = true;
                currentComboTime = defaultComboTime;

                if (currentComboState == ComboStates.HighKick)
                {
                    characterAnimation.HighKick();
                }

                if (currentComboState == ComboStates.KneeKick)
                {
                    characterAnimation.KneeKick();
                }



            }
        }

        private void ResetComboStates()
        {
            if (isTimeToRest)
            {
                currentComboTime -= Time.deltaTime;
                if (currentComboTime <= 0)
                {
                    currentComboState = ComboStates.None;
                    isTimeToRest = false;
                    currentComboTime = defaultComboTime;
                }
            }
        }
    }

    public enum ComboStates
    {
        None,
        PunchRight,
        PunchLeft,
        ElbowAttack,
        HighKick,
        KneeKick
    }
}
