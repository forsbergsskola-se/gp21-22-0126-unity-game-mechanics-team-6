using System.Collections;
using System.Collections.Generic;
using Team6.Toofan.Managers;
using UnityEngine;

namespace Team6.Toofan.Animations
{
    public class CharacterAnimationDelegate : MonoBehaviour
    {
        public GameObject leftHandAttackPoint;
        public GameObject leftElbowAttackPoint;
        public GameObject leftKneeAttackPoint;
        public GameObject leftFootAttackPoint;
        public GameObject rightHandAttackPoint;
        public GameObject rightElbowAttackPoint;
        public GameObject rightKneeAttackPoint;
        public GameObject rightFootAttackPoint;

        public float standUpTimer = 2f;
        private CharacterAnimation animationScript;

        private void Awake()
        {
            animationScript = GetComponent<CharacterAnimation>();
        }
        void LeftHandAttackOn()
        {
            leftHandAttackPoint.SetActive(true);
        }
        void LeftHandAttackOff()
        {
            if (leftHandAttackPoint.activeInHierarchy)
                leftHandAttackPoint.SetActive(false);
        }

        void RightHandAttackOn()
        {
            rightHandAttackPoint.SetActive(true);
        }
        void RightHandAttackOff()
        {
            if (rightHandAttackPoint.activeInHierarchy)
                rightHandAttackPoint.SetActive(false);
        }

        void LeftElbowAttackOn()
        {
            leftElbowAttackPoint.SetActive(true);
        }
        void LeftElbowAttackOff()
        {
            if (leftElbowAttackPoint.activeInHierarchy)
                leftElbowAttackPoint.SetActive(false);
        }

        void RightElbowAttackOn()
        {
            rightElbowAttackPoint.SetActive(true);
        }
        void RightElbowAttackOff()
        {
            if (rightElbowAttackPoint.activeInHierarchy)
                rightElbowAttackPoint.SetActive(false);
        }

        void LeftKneeAttackOn()
        {
            leftKneeAttackPoint.SetActive(true);
        }
        void LeftKneeAttackOff()
        {
            if (leftKneeAttackPoint.activeInHierarchy)
                leftKneeAttackPoint.SetActive(false);
        }

        void RightKneeAttackOn()
        {
            rightKneeAttackPoint.SetActive(true);
        }
        void RightKneeAttackOff()
        {
            if (rightKneeAttackPoint.activeInHierarchy)
                rightKneeAttackPoint.SetActive(false);
        }

        void LeftFootAttackOn()
        {
            leftFootAttackPoint.SetActive(true);
        }
        void LeftFootAttackOff()
        {
            if (leftFootAttackPoint.activeInHierarchy)
                leftFootAttackPoint.SetActive(false);
        }
        void RightFootAttackOn()
        {
            rightFootAttackPoint.SetActive(true);
        }
        void RightFootAttackOff()
        {
            if (rightFootAttackPoint.activeInHierarchy)
                rightFootAttackPoint.SetActive(false);
        }

        void TagRightArm()
        {
            rightElbowAttackPoint.tag = Tags.RIGHTARM_TAG;
        }
        void UnTagRightArm()
        {
            rightElbowAttackPoint.tag = Tags.UNTAGGED_TAG;
        }

        void TagLeftLeg()
        {
            leftFootAttackPoint.tag = Tags.LEFTLEG_TAG;
        }
        void UnTagLeftLeg()
        {
            leftFootAttackPoint.tag = Tags.UNTAGGED_TAG;
        }

        void EnemyStandUp()
        {
            StartCoroutine(StandUpAfterTimer());
        }
        IEnumerator StandUpAfterTimer()
        {
            yield return new WaitForSeconds(standUpTimer);
            animationScript.StandUp();
        }
    }
}
