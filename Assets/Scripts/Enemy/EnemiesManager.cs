using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public List<GameObject> enemies;

    [SerializeField] 
    private EnemySpawner _spawner;

    public void Awake()
    {
        _spawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnEnemySpawned(GameObject enemy)
    {
        enemies.Add(enemy);
    }
}
