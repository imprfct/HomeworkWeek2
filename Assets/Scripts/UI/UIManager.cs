using System;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using UI.HealthBar;
using UnityEngine;
using Random = System.Random;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] 
        private Canvas _canvas;
        
        [SerializeField]
        private GameObject _bonusPanelPrefab;
        [SerializeField] 
        private GameObject _winPrefab;
        [SerializeField]
        private GameObject _gameOverPrefab;
        
        [SerializeField]
        private GameObject _enemyHealthBarPrefab;
        [SerializeField] 
        private GameObject _playerHealthBarPrefab;
        
        private void Awake()
        {
            Instance = this;
        }
        
        public void SpawnBonusPanel(int bonusesCount, List<Bonus> bonusesViews)
        {
            var random = new Random();
            Instantiate(_bonusPanelPrefab, _canvas.transform, false);
                
            var bonuses = GameObject.FindGameObjectsWithTag("Bonus");
            for (int i = 0; i < bonusesCount; i++)
            {
                var randomBonus = bonusesViews[random.Next(bonusesViews.Count)];
                bonuses[i].GetComponent<BonusView>().Initialize(randomBonus);
            }
        }

        public void SpawnGameOverPanel()
        {
            Instantiate(_gameOverPrefab, _canvas.transform, false);
        }
        
        public void SpawnWinPanel()
        {
            Instantiate(_winPrefab, _canvas.transform, false);
        }
        
        public void CreateHealthBar(GameObject target)
        {
            GameObject healthBarObject;
            if (target.CompareTag(GlobalConstants.PlayerTag))
            {
                healthBarObject = Instantiate(_playerHealthBarPrefab);
            }
            else if (target.CompareTag(GlobalConstants.EnemyTag))
            {
                healthBarObject = Instantiate(_enemyHealthBarPrefab);
            }
            else
            {
                throw new Exception("You are trying to create health bar " +
                                    "not to enemy or player");
            }
        
            var healthBar = healthBarObject.GetComponent<HealthBar.HealthBar>();
            healthBar.SetHealthBarData(target.transform,
                _canvas.GetComponent<RectTransform>());

            target.transform.gameObject.GetComponent<HealthBarController>().HealthBar = healthBar;
        }
    }
}