using PlayerScripts;
using UnityEngine;

namespace Bonuses
{
    public class SpeedBonus : Bonus
    {
        [SerializeField] 
        private float _speedBonusPercent = .3f;
        
        private static readonly int SpeedMultiplier = Animator.StringToHash("SpeedMultiplier");
    
        public override void ApplyEffect(Player player)
        {
            var movementController = player.MovementController;
            movementController._speed += movementController._speed * _speedBonusPercent;
            
            var animator = player.Animator;
            var newSpeed = animator.GetFloat(SpeedMultiplier) + _speedBonusPercent;
            animator.SetFloat(SpeedMultiplier, newSpeed);
        }
    }
}