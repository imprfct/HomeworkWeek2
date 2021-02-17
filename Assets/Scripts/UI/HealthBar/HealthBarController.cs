using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealthBarController : MonoBehaviour
{
    [NonSerialized]
    public HealthBar HealthBar;

    [SerializeField]
    private GameLogic _gameLogic; 
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

    private void OnCollisionEnter(Collision other)
    {
        TakeDamage(by: other.collider.tag);
        
        if (IsDead())
        {
            // Если умер враг
            if (gameObject.CompareTag("Enemy"))
            {
                EnemyDeath(0.5f);
            }
            // Если умер игрок
            else if (gameObject.CompareTag("Player"))
            {
                _gameLogic.GameOver();
            }
        }
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
            
            case "Enemy":
                _currentHealthPoints -= _damageByHitWithPlayer;
                break;
        }
        
        HealthBar.SetHealthInPercents(CalculatePercentHp(_currentHealthPoints));
    }

    public void EnemyDeath(float latencyBeforeDeath)
    {
        var enemy = gameObject.GetComponent<EnemyMovingController>();
        
        enemy.IsAlive = false;
        enemy.IsMoving = false;

        HealthBar.SetHealthInPercents(0f);
        
        Destroy(HealthBar.gameObject, latencyBeforeDeath);
        Destroy(gameObject, latencyBeforeDeath);
    }
    
    public bool IsDead()
    {
        if (_currentHealthPoints <= 0)
            return true;

        return false;
    }
    
    private float CalculatePercentHp(float hp)
    {
        return Mathf.Clamp(hp / _maxHealthPoints, 0, 1);
    }
}
