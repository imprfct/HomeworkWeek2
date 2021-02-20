using System.Collections.Generic;
using UI.HealthBar;
using UnityEngine;

namespace Enemy
{
    public class EnemiesManager : MonoBehaviour
    {
        public static EnemiesManager Instance { get; private set; }
        public List<GameObject> Enemies { get;} = new List<GameObject>();
        
        [SerializeField] 
        private EnemySpawner _spawner;

        private void Awake()
        {
            Instance = this;
        
            _spawner.EnemySpawned += OnEnemySpawned;
            HealthBarController.EnemyDie += OnEnemyDeath;
        }

        private void OnEnemySpawned(GameObject enemy)
        {
            Enemies.Add(enemy);
        }
        
        private void OnEnemyDeath(GameObject enemy)
        {
            Enemies.Remove(enemy);
        }

        private void OnDestroy()
        {
            _spawner.EnemySpawned -= OnEnemySpawned;
            HealthBarController.EnemyDie -= OnEnemyDeath;
        }
    }
}
