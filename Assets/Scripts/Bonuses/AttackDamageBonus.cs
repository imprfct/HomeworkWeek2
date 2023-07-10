using PlayerScripts;
using UnityEngine;

namespace Bonuses
{
    public class AttackDamageBonus : Bonus
    {
        [SerializeField] 
        private float _damageToAdd = 25f;
    
        public override void ApplyEffect(Player player)
        {
            var shootingController = player.ShootingController;
            shootingController.minDamage += _damageToAdd;
            shootingController.maxDamage += _damageToAdd;
        }
    }
}