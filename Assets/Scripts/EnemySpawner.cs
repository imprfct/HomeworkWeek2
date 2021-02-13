using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action<GameObject> EnemySpawned; 
    
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private RectTransform targetCanvas;
    [SerializeField] private TerrainPointProvider pointProvider;
    
    [SerializeField] private float newEnemyCooldown = 5;
    private float _elapsedTimeSinceLastSpawn;

    private void Update()
    {
        _elapsedTimeSinceLastSpawn += Time.deltaTime;
        
        if(IsCooldownExpired())
            SpawnEnemy();
        
        _elapsedTimeSinceLastSpawn %= newEnemyCooldown;
    }

    private bool IsCooldownExpired()
    {
        if (_elapsedTimeSinceLastSpawn < newEnemyCooldown)
            return false;

        return true;
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(enemyPrefab, pointProvider.GetPoint(), Quaternion.identity);
        enemy.GetComponent<HealthBarController>().HealthBar = CreateHealthBar(enemy);
        EnemySpawned?.Invoke(enemy);
    }

    private HealthBar CreateHealthBar(GameObject enemy)
    {
        var healthBarObject = Instantiate(healthBarPrefab);
        
        var healthBar = healthBarObject.GetComponent<HealthBar>();
        healthBar.SetHealthBarData(enemy.transform, targetCanvas);

        return healthBar;
    }
}
