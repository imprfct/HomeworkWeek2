using UnityEngine;

namespace Assets.Scripts.Bonuses
{
    public class AttackSpeedBonus : Bonus
    {
        private static readonly int AttackSpeedMultiplier = Animator.StringToHash("AttackSpeedMultiplier");

        [SerializeField] 
        private float _attackSpeedBonusPercent = .5f;

        public override void Effect(GameObject player)
        {
            base.Effect(player);

            var animator = Player.GetComponent<Animator>();
            var newAttackSpeed = animator.GetFloat(AttackSpeedMultiplier) + _attackSpeedBonusPercent;
            animator.SetFloat(AttackSpeedMultiplier, newAttackSpeed);
            
            Debug.Log("Added AttackSpeed to player");
        }
    }
}