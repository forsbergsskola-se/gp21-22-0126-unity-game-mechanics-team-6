using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Team6.Toofan.Managers
{
    public class AnimationTags
    {
        public const string SPEED = "Speed";

        public const string BOXINGLEFT_TRIGGER = "BoxingLeft";
        public const string BOXINGRIGHT_TRIGGER = "BoxingRight";
        public const string ELBOWPUNCH_TRIGGER = "ElbowPunch";

        public const string FLYINGKICK_TRIGGER = "FlyingKick";
        public const string HIGHKICK_TRIGGER = "HighKick";

        public const string KNEEKICK_TRIGGER = "KneeKick";
        public const string KNOCKDOWN_TRIGGER = "KnockDown";
        public const string HIT_TRIGGER = "Hit";

        public const string STANDUP_TRIGGER = "StandUp";

        public const string DEAD_TRIGGER = "isDead";
        public const string IsDEAD_TRIGGER = "isDead_1";
    }

    public class Tags
    {
        public const string PLAYER_TAG = "Player";
        public const string GROUND_TAG = "Ground";
        public const string ENEMY_TAG = "Enemy";
        public const string MAINCAMERA_TAG = "MainCamera";
        public const string LEFTARM_TAG = "LeftArm";
        public const string LEFTLEG_TAG = "LeftLeg";
        public const string RIGHTARM_TAG = "RightArm";
        public const string RIGHTLEG_TAG = "RightLeg";
        public const string UNTAGGED_TAG = "Untagged";
    }

    public class Axis
    {
        public const string HORIZONTAL_AXIS = "Horizontal";
        public const string VERTICAL_AXIS = "Vertical";
    }



}