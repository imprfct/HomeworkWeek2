using System.Collections.Generic;
using UI.HealthBar;
using UnityEngine;

namespace EnemyScripts
{
    public class EnemiesManager : MonoBehaviour
    {
        public static EnemiesManager Instance { get; private set; }
        public List<Enemy> Enemies { get;} = new List<Enemy>();
        
        [SerializeField] 
        private EnemySpawner _spawner;

        private void Awake()
        {
            Instance = this;
        
            _spawner.EnemySpawned += OnEnemySpawned;
            HealthBarController.EnemyDie += OnEnemyDeath;
        }

        private void OnEnemySpawned(Enemy enemy)
        {
            Enemies.Add(enemy);
        }
        
        private void OnEnemyDeath(Enemy enemy)
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
