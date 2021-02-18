using System;
using Assets.Scripts.UI;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [NonSerialized]
    public HealthBar HealthBar;
    
    [SerializeField]
    private GameLogic _gameLogic; 
    
    [SerializeField] 
    private float _damageByHitWithPlayer = 30f;
    
    [SerializeField]
    private KilledEnemiesUpdater _labelUpdater;
    
    public float MaxHealthPoints = 100;
    public float CurrentHealthPoints;
    
    
    
    private void Start()
    {
        CurrentHealthPoints = MaxHealthPoints;
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
    
    public void TakeDamage(float damage)
    {
        CurrentHealthPoints -= damage;
    }
    
    private void TakeDamage(string by)
    {
        switch (by)
        {
            case "Player":
                CurrentHealthPoints -= _damageByHitWithPlayer;
                break;
            
            case "Enemy":
                CurrentHealthPoints -= _damageByHitWithPlayer;
                break;
        }
        
        HealthBar.SetHealthInPercents(CalculatePercentHp(CurrentHealthPoints));
    }

    public void EnemyDeath(float latencyBeforeDeath)
    {
        var enemy = gameObject.GetComponent<EnemyMovingController>();
        
        enemy.IsAlive = false;
        enemy.IsMoving = false;
        
        enemy.Agent.speed = 0;
        
        HealthBar.SetHealthInPercents(0f);

        _labelUpdater.IncrementKilledEnemiesCounter();

        Destroy(HealthBar.gameObject, latencyBeforeDeath);
        Destroy(gameObject, latencyBeforeDeath);
    }
    
    public bool IsDead()
    {
        if (CurrentHealthPoints <= 0)
            return true;

        return false;
    }
    
    private float CalculatePercentHp(float hp)
    {
        return Mathf.Clamp(hp / MaxHealthPoints, 0, 1);
    }
}
