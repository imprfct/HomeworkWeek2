using System.Collections.Generic;
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
        private GameObject _bonusPanelPrefab;
        [SerializeField] 
        private Canvas _canvas;
        
        [SerializeField] 
        private int _countOfEnemiesToGetBonus = 5;
        
        private int _lastKilledEnemiesCount = -1;
        
        private void Update()
        {
            int killedEnemiesCount = int.Parse(_killedEnemiesCounter.text);
            
            if (ShouldSpawnBonusPanel(killedEnemiesCount))
            {
                SpawnBonusPanel();
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
        
        private void SpawnBonusPanel()
        {
            var random = new Random();
            Instantiate(_bonusPanelPrefab, _canvas.transform, false);
                
            var bonuses = GameObject.FindGameObjectsWithTag("Bonus");
            for (int i = 0; i < _bonusesCount; i++)
            {
                var randomBonus = _bonuses[random.Next(_bonuses.Count)];
                bonuses[i].GetComponent<BonusView>().Initialize(randomBonus);
            }
        }
    }
}
