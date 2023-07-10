using System.Collections.Generic;
using EnemyScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerShootingController : MonoBehaviour
    {
        [SerializeField]
        public float maxDamage = 20f;

        [SerializeField] 
        public float minDamage = 50f;
    
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
    
        private GameObject _closestEnemy;
    
        public void Update()
        {
            var enemies = EnemiesManager.Instance.Enemies;
        
            if (_elapsedTimeSinceLastShoot < _shootCooldown)
            {
                if (enemies.Count > 0)
                {
                    FindClosestEnemy(enemies);
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
    
        private void Shoot()
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

        private void FindClosestEnemy(List<Enemy> enemiesList)
        {
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;

            GameObject closest = null;

            foreach (var enemy in enemiesList)
            {
                var enemyObject = enemy.gameObject;
            
                var distanceToEnemy = Vector3.Distance(transform.position,
                    enemyObject.transform.position);

                if (distanceToEnemy > _attackRadius)
                    continue;

                Vector3 diff = enemyObject.transform.position - position;
                float currentDistance = diff.sqrMagnitude;
                if (currentDistance < distance && enemy.HealthBarController.IsDead() == false)
                {
                    closest = enemyObject;
                    distance = currentDistance;
                }
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
}
