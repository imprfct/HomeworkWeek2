using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.Scripts.Bonuses
{
    public class BonusSystem : MonoBehaviour
    {
        [SerializeField]
        private GameObject _player;

        [SerializeField] 
        private Text _killedEnemiesCounter;
        
        [SerializeField]
        private List<Bonus> _bonuses;

        private int _lastKilledEnemiesCount = -1;
        
        private void Update()
        {
            int killedEnemiesCount = int.Parse(_killedEnemiesCounter.text);
            
            if (NeedsNewBuff(killedEnemiesCount))
            {
                var randomBonus = _bonuses[new Random().Next(_bonuses.Count)];
                randomBonus.Effect(_player);
            }        
            
            _lastKilledEnemiesCount = killedEnemiesCount;
        }

        private bool NeedsNewBuff(int value)
        {
            if ((_lastKilledEnemiesCount != value) && (value % 5 == 0))
                return true;

            return false;
        }
    }
}
