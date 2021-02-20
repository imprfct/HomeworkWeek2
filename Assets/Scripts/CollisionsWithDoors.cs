using System;
using Assets.Scripts.Utils;
using UI.HealthBar;
using UnityEngine;

public class CollisionsWithDoors : MonoBehaviour
{
    public Action OnEnemyReachedTargetDoor;
    
    [SerializeField] 
    private GameLogic _game;

    private void OnCollisionEnter(Collision other)
    {
        // Если обрабатываем дверь, куда стремится враг
        if (CompareTag(GlobalConstants.EnterDoorTag))
        {
            if (other.collider.CompareTag(GlobalConstants.EnemyTag))
            {
                OnEnemyReachedTargetDoor.Invoke();
                other.collider.gameObject.GetComponent<HealthBarController>().EnemyDeath(0f);
            }
        }
        
        // Если обрабатываем дверь, куда нужно попасть игроку
        if (CompareTag(GlobalConstants.ExitDoorTag))
        {
            if (other.collider.CompareTag(GlobalConstants.PlayerTag))
            {
                _game.Win();
            }
        }
    }
}
