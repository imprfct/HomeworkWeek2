using System;
using Assets.Scripts.Utils;
using EnemyScripts;
using UnityEngine;
using UnityEngine.Events;

namespace UI.HealthBar
{
    public class HealthBarController : MonoBehaviour
    {
        public static UnityAction<Enemy> EnemyDie;
        
        [NonSerialized]
        public HealthBar HealthBar;
    
        [SerializeField] 
        private float _damageByHitWithPlayer = 30f;
    
        [SerializeField]
        private KilledEnemiesUpdater _labelUpdater;

        public float MaxHealthPoints { get; set; } = 100;
        public float CurrentHealthPoints { get; set; }
    
        private void Start()
        {
            CurrentHealthPoints = MaxHealthPoints;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag(GlobalConstants.EnemyTag) ||
                other.gameObject.CompareTag(GlobalConstants.PlayerTag))
            {
                TakeDamage(_damageByHitWithPlayer);
            }
        }
    
        public void TakeDamage(float damage)
        {
            CurrentHealthPoints -= damage;
            HealthBar.SetHealthInPercents(CalculatePercentHp(CurrentHealthPoints));
            CheckForDeath();
        }

        private void CheckForDeath()
        {
            if (IsDead())
            {
                // Если умер враг
                if (gameObject.CompareTag(GlobalConstants.EnemyTag))
                {
                    EnemyDeath(0.5f);
                }
                // Если умер игрок
                else if (gameObject.CompareTag(GlobalConstants.PlayerTag))
                {
                    GameLogic.Instance.GameOver();
                }
            }
        }
    
        public bool IsDead()
        {
            if (CalculatePercentHp(CurrentHealthPoints) == 0)
                return true;

            return false;
        }
    
        public void EnemyDeath(float latencyBeforeDeath)
        {
            var enemy = gameObject.GetComponent<EnemyMovingController>();
        
            enemy.IsAlive = false;
            enemy.IsMoving = false;
        
            HealthBar.SetHealthInPercents(0f);

            _labelUpdater.IncrementKilledEnemiesCounter();

            Destroy(HealthBar.gameObject, latencyBeforeDeath);
            Destroy(gameObject, latencyBeforeDeath);
            
            EnemyDie?.Invoke(gameObject.GetComponent<Enemy>());
        }
    
        private float CalculatePercentHp(float hp)
        {
            return Mathf.Clamp(hp / MaxHealthPoints, 0, 1);
        }
    }
}
