using PlayerScripts;
using UnityEngine;

namespace Bonuses
{
    public class HealthPointsBonus : Bonus
    {
        [SerializeField] 
        private float _healthToAdd = 25f;

        public override void ApplyEffect(Player player)
        {
            var healthBarController = player.HealthBarController;
            healthBarController.MaxHealthPoints += _healthToAdd;
            healthBarController.CurrentHealthPoints += _healthToAdd;
        }
    }
}
