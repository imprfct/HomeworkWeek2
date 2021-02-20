using System;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public event Action<GameObject> EnemySpawned; 
    
        [SerializeField] 
        private GameObject _enemyPrefab;
    
        [SerializeField]
        private TerrainPointProvider _pointProvider;
    
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
            var enemy = Instantiate(_enemyPrefab, _pointProvider.GetPoint(), Quaternion.identity);
            EnemySpawned?.Invoke(enemy);
        }
    }
}
