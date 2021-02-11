using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private EnemiesManager enemiesManager;
    [SerializeField] private GameObject shardPrefab;
    [SerializeField] private GameObject spawner;
    
    [SerializeField] private float shootCooldown = 1;
    [SerializeField] private float attackRadius = 50f;
    [SerializeField] private float shardSpeed = 150f;
    private float _elapsedTimeSinceLastShoot;
    
    private List<GameObject> _enemies;
    private GameObject _closestEnemy;
    private void Start()
    {
        _enemies = enemiesManager.enemies;
    }

    public void Update()
    {
        if (_enemies.Count > 0)
            FindClosestEnemy();
        
        IterateCooldown();
    }

    private void IterateCooldown()
    {
        _elapsedTimeSinceLastShoot += Time.deltaTime;
        _elapsedTimeSinceLastShoot %= shootCooldown;
    }
    
    public void Shoot()
    {
        /*
         * Эта процедура вызывается из ивента анимации атаки в момент, когда анимация каста окончена
         */
        
        var spawnerPosition = spawner.transform.position;
        var enemyPosition = _closestEnemy.transform.position;
        var directionToTarget = (enemyPosition - spawnerPosition).normalized;
        
        transform.LookAt(_closestEnemy.transform);
        var shard = Instantiate(shardPrefab,
            spawnerPosition, Quaternion.identity);
        shard.transform.LookAt(_closestEnemy.transform);
        shard.GetComponent<Rigidbody>().velocity = directionToTarget * shardSpeed * Time.time;
    }

    void FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        GameObject closest = null;
        foreach (var enemy in _enemies)
        {
            var distanceToEnemy = Vector3.Distance(transform.position,
                enemy.transform.position);
            
            if(distanceToEnemy > attackRadius)
                continue;
            
            Vector3 diff = enemy.transform.position - position;
            float currentDistance = diff.sqrMagnitude;
            if (currentDistance < distance)
            {
                closest = enemy;
                distance = currentDistance;
            }
        }

        _closestEnemy = closest;
    }

    public bool PlayerMayAttackEnemy()
    {
        if (_closestEnemy)
            return true;

        return false;
    }
}
