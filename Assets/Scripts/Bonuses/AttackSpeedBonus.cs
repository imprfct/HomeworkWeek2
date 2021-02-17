using UnityEngine;

namespace Assets.Scripts.Bonuses
{
    public class AttackSpeedBonus : Bonus
    {
        [SerializeField] 
        private float _attackSpeedBonusPercent = .5f;
        
        private static readonly int AttackSpeedMultiplier = Animator.StringToHash("AttackSpeedMultiplier");
        
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