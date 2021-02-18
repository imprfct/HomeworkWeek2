using UnityEngine;

namespace Assets.Scripts.Bonuses
{
    public class SpeedBonus : Bonus
    {
        [SerializeField] 
        private float _speedBonusPercent = .3f;
        
        private static readonly int SpeedMultiplier = Animator.StringToHash("SpeedMultiplier");
    
        public override void Effect(GameObject player)
        {
            base.Effect(player);

            var movementController = Player.GetComponent<PlayerMovementController>();
            movementController._speed += movementController._speed * _speedBonusPercent;
            
            var animator = Player.GetComponent<Animator>();
            var newSpeed = animator.GetFloat(SpeedMultiplier) + _speedBonusPercent;
            animator.SetFloat(SpeedMultiplier, newSpeed);

            Debug.Log("Added SPD to player");
        }
    }
}