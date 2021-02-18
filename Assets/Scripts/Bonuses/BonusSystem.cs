using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace Assets.Scripts.Bonuses
{
    public class BonusSystem : MonoBehaviour
    {
        [SerializeField] 
        private Text _killedEnemiesCounter;
        
        [SerializeField]
        private List<Bonus> _bonuses;

        [SerializeField] 
        private GameObject _bonusPanelPrefab;
        [SerializeField] 
        private Canvas _canvas;
        
        [SerializeField] 
        private int _CountOfEnemiesToGetBonus = 5;
        
        private int _lastKilledEnemiesCount = -1;
        
        private void Update()
        {
            int killedEnemiesCount = int.Parse(_killedEnemiesCounter.text);
            
            if (NeedsNewBuff(killedEnemiesCount))
            {
                SpawnBonusPanel();
                Time.timeScale = 0;
            }        
            
            _lastKilledEnemiesCount = killedEnemiesCount;
        }

        private bool NeedsNewBuff(int value)
        {
            if ((_lastKilledEnemiesCount != value) &&
                (value % _CountOfEnemiesToGetBonus == 0))
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
            for (int i = 0; i < 3; i++)
            {
                var randomBonus = _bonuses[random.Next(_bonuses.Count)];
                bonuses[i].GetComponent<BonusSetter>().SetBonus(randomBonus);
            }
        }
    }
}
