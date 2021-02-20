using PlayerScripts;
using UnityEngine;

namespace Bonuses
{
    public class AttackSpeedBonus : Bonus
    {
        private static readonly int AttackSpeedMultiplier = Animator.StringToHash("AttackSpeedMultiplier");

        [SerializeField] 
        private float _attackSpeedBonusPercent = .5f;

        public override void ApplyEffect(Player player)
        {
            var animator = player.Animator;
            var newAttackSpeed = animator.GetFloat(AttackSpeedMultiplier) + _attackSpeedBonusPercent;
            animator.SetFloat(AttackSpeedMultiplier, newAttackSpeed);
        }
    }
}