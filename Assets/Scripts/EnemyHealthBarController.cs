using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealthBarController : MonoBehaviour
{    
    [SerializeField] private EnemyMovingController enemy;
    [NonSerialized] public HealthBar HealthBar;

    [SerializeField] private float minimalDamageByShard = 20f;
    [SerializeField] private float maximumDamageByShard = 60f;

    [SerializeField] private float damageByHitWithPlayer = 30f;

    [SerializeField] private float maxHealthPoints = 100;
    private float _currentHealthPoints;

    private void Start()
    {
        _currentHealthPoints = maxHealthPoints;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(by: other.tag);
        
        if(IsDead())
            KillEnemy();
    }

    private void TakeDamage(string by)
    {
        switch (by)
        {
            case "Shard":
                _currentHealthPoints -= Random.Range(minimalDamageByShard, maximumDamageByShard);
                break;
            
            case "Player":
                _currentHealthPoints -= damageByHitWithPlayer;
                break;
        }
        
        HealthBar.SetHealthInPercents(CalculatePercentHp(_currentHealthPoints));
    }
    
    public bool IsDead()
    {
        if (_currentHealthPoints <= 0)
            return true;

        return false;
    }

    private void KillEnemy()
    {
        enemy.IsAlive = false;
        enemy.IsMoving = false;

        HealthBar.SetHealthInPercents(0f);
        
        Destroy(HealthBar.gameObject, 0.5f);
        Destroy(gameObject, 0.5f);
    }
    
    private float CalculatePercentHp(float hp)
    {
        return Mathf.Clamp(hp / maxHealthPoints, 0, 1);
    }
}