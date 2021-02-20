using System;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemySpawner : MonoBehaviour
    {
        public event Action<Enemy> EnemySpawned; 
    
        [SerializeField] 
        private GameObject _enemyPrefab;
    
        [SerializeField]
        private float _newEnemyCooldown = 5;
    
        private float _elapsedTimeSinceLastSpawn;

        private void Update()
        {
            _elapsedTimeSinceLastSpawn += Time.deltaTime;
        
            if(IsCooldownExpired())
                SpawnEnemy();
        
            _elapsedTimeSinceLastSpawn %= _newEnemyCooldown;
        }

        private bool IsCooldownExpired()
        {
            if (_elapsedTimeSinceLastSpawn < _newEnemyCooldown)
                return false;

            return true;
        }

        private void SpawnEnemy()
        {
            var enemy = Instantiate(_enemyPrefab,
                TerrainPointProvider.Instance.GetPoint(), Quaternion.identity);
            EnemySpawned?.Invoke(enemy.GetComponent<Enemy>());
        }
    }
}
