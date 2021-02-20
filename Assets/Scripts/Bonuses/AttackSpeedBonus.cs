using UnityEngine;

namespace Assets.Scripts.Bonuses
{
    public class AttackSpeedBonus : Bonus
    {
        private static readonly int AttackSpeedMultiplier = Animator.StringToHash("AttackSpeedMultiplier");

        [SerializeField] 
        private float _attackSpeedBonusPercent = .5f;

        public override void ApplyEffect(GameObject player)
        {
            var animator = player.GetComponent<Animator>();
            var newAttackSpeed = animator.GetFloat(AttackSpeedMultiplier) + _attackSpeedBonusPercent;
            animator.SetFloat(AttackSpeedMultiplier, newAttackSpeed);
        }
    }
}