using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    public List<GameObject> enemies;

    public void Awake()
    {
        _spawner.EnemySpawned += OnEnemySpawned;
    }

    private void OnEnemySpawned(GameObject enemy)
    {
        enemies.Add(enemy);
    }
}
