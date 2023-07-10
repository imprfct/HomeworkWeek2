using EnemyScripts;
using UnityEngine;

namespace UI
{
    public class HealthBarsManager : MonoBehaviour
    {
        [SerializeField]
        private EnemySpawner _spawner;
        [SerializeField]
        private GameObject _player;

        private void Start()
        {
            UIManager.Instance.CreateHealthBar(_player);
            _spawner.EnemySpawned += EnemySpawned;
        }

        private void EnemySpawned(Enemy enemy)
        {
            UIManager.Instance.CreateHealthBar(enemy.gameObject);
        }
    
        private void OnDestroy()
        {
            _spawner.EnemySpawned -= EnemySpawned;
        }
    }
}