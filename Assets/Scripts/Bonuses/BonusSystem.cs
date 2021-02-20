using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.Scripts.Bonuses
{
    public class BonusSystem : MonoBehaviour
    {
        private const int _bonusesCount = 3;
        
        [SerializeField] 
        private Text _killedEnemiesCounter;
        
        [SerializeField]
        private List<Bonus> _bonuses;

        [SerializeField] 
        private int _countOfEnemiesToGetBonus = 5;
        
        private int _lastKilledEnemiesCount = -1;
        
        private void Update()
        {
            int killedEnemiesCount = int.Parse(_killedEnemiesCounter.text);
            
            if (ShouldSpawnBonusPanel(killedEnemiesCount))
            {
                UIManager.Instance.SpawnBonusPanel(_bonusesCount, _bonuses);
                Time.timeScale = 0;
            }        
            
            _lastKilledEnemiesCount = killedEnemiesCount;
        }

        private bool ShouldSpawnBonusPanel(int killedEnemiesCount)
        {
            if ((_lastKilledEnemiesCount != killedEnemiesCount) &&
                (killedEnemiesCount % _countOfEnemiesToGetBonus == 0))
            {
                return true;
            }

            return false;
        }
    }
}
