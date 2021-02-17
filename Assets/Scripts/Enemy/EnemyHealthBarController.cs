using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealthBarController : MonoBehaviour
{
    [NonSerialized] public HealthBar HealthBar;

    [SerializeField] 
    private EnemyMovingController _enemy;

    [SerializeField] 
    private float _minimalDamageByShard = 20f;
    [SerializeField]
    private float _maximumDamageByShard = 60f;

    [SerializeField] 
    private float _damageByHitWithPlayer = 30f;

    [SerializeField] 
    private float _maxHealthPoints = 100;
    private float _currentHealthPoints;

    private void Start()
    {
        _currentHealthPoints = _maxHealthPoints;
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
                _currentHealthPoints -= Random.Range(_minimalDamageByShard, _maximumDamageByShard);
                break;
            
            case "Player":
                _currentHealthPoints -= _damageByHitWithPlayer;
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
        _enemy.IsAlive = false;
        _enemy.IsMoving = false;

        HealthBar.SetHealthInPercents(0f);
        
        Destroy(HealthBar.gameObject, 0.5f);
        Destroy(gameObject, 0.5f);
    }
    
    private float CalculatePercentHp(float hp)
    {
        return Mathf.Clamp(hp / _maxHealthPoints, 0, 1);
    }
}