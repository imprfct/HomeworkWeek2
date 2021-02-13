using UnityEngine;

public class CollisionsWithDoors : MonoBehaviour
{
    [SerializeField] private GameLogic game;

    private void OnCollisionEnter(Collision other)
    {
        // Если обрабатываем дверь, куда стремится враг
        if(CompareTag("EnterDoor"))
            if (other.collider.CompareTag("Enemy"))
                game.GameOver();
        
        // Если обрабатываем дверь, куда нужно попасть игроку
        if(CompareTag("ExitDoor"))
            if(other.collider.CompareTag("Player"))
                game.Win();
    }
}
