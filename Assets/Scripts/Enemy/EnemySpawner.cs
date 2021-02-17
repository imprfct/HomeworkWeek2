using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action<GameObject> EnemySpawned; 
    
    [SerializeField] 
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _healthBarPrefab;
    
    [SerializeField]
    private RectTransform _targetCanvas;
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
        enemy.GetComponent<HealthBarController>().HealthBar = CreateHealthBar(enemy);
        EnemySpawned?.Invoke(enemy);
    }

    private HealthBar CreateHealthBar(GameObject enemy)
    {
        var healthBarObject = Instantiate(_healthBarPrefab);
        
        var healthBar = healthBarObject.GetComponent<HealthBar>();
        healthBar.SetHealthBarData(enemy.transform, _targetCanvas);

        return healthBar;
    }
}
