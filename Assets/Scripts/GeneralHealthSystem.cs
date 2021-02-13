using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralHealthSystem : MonoBehaviour
{
    [SerializeField] private List<Image> lives;
    private int _livesCount;
    
    [SerializeField] private CollisionsWithDoors enterDoorCollisionScript;
    [SerializeField] private GameLogic _gameLogic;
    
    private void Awake()
    {
        _livesCount = lives.Count;
        enterDoorCollisionScript.OnEnemyReachedTargetDoor += OnEnemyReachedTargetDoor;
    }

    private void OnEnemyReachedTargetDoor()
    {
        var liveIndex = _livesCount - 1;
        
        if (liveIndex == 0)
        {
            Destroy(lives[liveIndex].gameObject);
            _gameLogic.GameOver();
            return;
        }
        
        Destroy(lives[liveIndex].gameObject);
        lives.RemoveAt(liveIndex);
        
        _livesCount -= 1;
    }
}
