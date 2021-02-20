using System;
using Enemy;
using UI.HealthBar;
using UnityEngine;

namespace UI
{
    public class HealthBarsManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _enemyHealthBarPrefab;
        [SerializeField] 
        private GameObject _healthBarPrefab;

        [SerializeField]
        private EnemySpawner _spawner;
        [SerializeField]
        private Transform _playerTransform;
        [SerializeField]
        private RectTransform _canvas;

        private void Start()
        {
            CreateHealthBarForPlayer();
            _spawner.EnemySpawned += EnemySpawned;
        }

        private void CreateHealthBarForPlayer()
        {
            var healthBarObject = Instantiate(_healthBarPrefab);
        
            var healthBar = healthBarObject.GetComponent<HealthBar.HealthBar>();
            healthBar.SetHealthBarData(_playerTransform, _canvas);

            _playerTransform.gameObject.GetComponent<HealthBarController>().HealthBar = healthBar;
        }

        private void EnemySpawned(GameObject enemy)
        {
            CreateHealthBar(enemy);
        }
    
        private void CreateHealthBar(GameObject enemy)
        {
            var healthBarObject = Instantiate(_enemyHealthBarPrefab);
            var healthBar = healthBarObject.GetComponent<HealthBar.HealthBar>();
            healthBar.SetHealthBarData(enemy.transform, _canvas);
        
            enemy.GetComponent<HealthBarController>().HealthBar = healthBar;
        }

        private void OnDestroy()
        {
            _spawner.EnemySpawned -= EnemySpawned;
        }
    }
}