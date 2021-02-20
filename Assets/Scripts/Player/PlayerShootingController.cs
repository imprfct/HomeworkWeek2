using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField]
    public float maxDamage = 20f;

    [SerializeField] 
    public float minDamage = 50f;
    
    [SerializeField] 
    private EnemiesManager _enemiesManager;
    [SerializeField]
    private GameObject _shardPrefab;
    [SerializeField]
    private GameObject _spawner;
    
    [SerializeField]
    private float _shootCooldown = 1;
    [SerializeField]
    private float _attackRadius = 50f;
    [SerializeField]
    private float _shardSpeed = 150f;
    private float _elapsedTimeSinceLastShoot;
    
    private List<GameObject> _enemies;
    private GameObject _closestEnemy;
    private void Start()
    {
        _enemies = _enemiesManager.enemies;
    }

    public void Update()
    {
        if (_elapsedTimeSinceLastShoot < _shootCooldown)
        {
            if (_enemies.Count > 0)
            {
                FindClosestEnemy();
            }

            _elapsedTimeSinceLastShoot = 0;
        }
        
        
        IterateCooldown();
    }

    private void IterateCooldown()
    {
        _elapsedTimeSinceLastShoot += Time.deltaTime;
        _elapsedTimeSinceLastShoot %= _shootCooldown;
    }
    
    public void Shoot()
    {
        /*
         * Эта процедура вызывается из ивента анимации атаки в момент, когда анимация каста окончена
         */
        if (_closestEnemy != null)
        {
            var spawnerPosition = _spawner.transform.position;
            var enemyPosition = _closestEnemy.transform.position;
            
            var directionToTarget = (enemyPosition - spawnerPosition).normalized;
            directionToTarget.y = 1; // Чтобы всегда летело прямо, без искажений по y
            
            transform.LookAt(_closestEnemy.transform);
            var shard = Instantiate(_shardPrefab,
                spawnerPosition, Quaternion.identity);
            var shardSettings = shard.GetComponent<ShardHitManager>();
            shardSettings.MinDamage = minDamage;
            shardSettings.MaxDamage = maxDamage;
            
            shard.transform.LookAt(_closestEnemy.transform);
            shard.GetComponent<Rigidbody>().velocity = directionToTarget * _shardSpeed * Time.time;
        }
    }

    void FindClosestEnemy()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        GameObject closest = null;

        foreach (var enemy in _enemies)
        {
            try
            {
                var distanceToEnemy = Vector3.Distance(transform.position,
                    enemy.transform.position);

                if (distanceToEnemy > _attackRadius)
                    continue;

                Vector3 diff = enemy.transform.position - position;
                float currentDistance = diff.sqrMagnitude;
                if (currentDistance < distance && enemy.GetComponent<HealthBarController>().IsDead() == false)
                {
                    closest = enemy;
                    distance = currentDistance;
                }
            }
            /*
             * Появляется, когда стреляем по врагу, который остался в _enemies, но уже удален со сцены
             * Эта проблема связана с тем, что враг является префабом и я не могу дать ему ссылку на массив _enemies
             *  Решение лучше чем это я просто не смог придумать...
             */
            catch (MissingReferenceException){ }
        }
        
        _closestEnemy = closest;
    }

    public bool CouldAttackEnemy()
    {
        if (_closestEnemy)
            return true;

        return false;
    }
}
