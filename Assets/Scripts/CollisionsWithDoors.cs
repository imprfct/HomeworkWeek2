using System;
using UnityEngine;

public class CollisionsWithDoors : MonoBehaviour
{
    public Action OnEnemyReachedTargetDoor;
    
    [SerializeField] 
    private GameLogic _game;

    private void OnCollisionEnter(Collision other)
    {
        // Если обрабатываем дверь, куда стремится враг
        if (CompareTag("EnterDoor"))
        {
            if (other.collider.CompareTag("Enemy"))
            {
                OnEnemyReachedTargetDoor.Invoke();
                other.collider.gameObject.GetComponent<HealthBarController>().EnemyDeath(0f);
            }
        }
        
        // Если обрабатываем дверь, куда нужно попасть игроку
        if (CompareTag("ExitDoor"))
        {
            if (other.collider.CompareTag("Player"))
            {
                _game.Win();
            }
        }
    }
}
