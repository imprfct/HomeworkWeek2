using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralHealthSystem : MonoBehaviour
{
    private int _livesCount;

    [SerializeField] 
    private List<Image> _lives;
    [SerializeField]
    private Sprite _emptyHeart;
    
    [SerializeField]
    private CollisionsWithDoors _enterDoorCollisionScript;
    [SerializeField]
    private GameLogic _gameLogic;
    
    private void Awake()
    {
        _livesCount = _lives.Count;
        _enterDoorCollisionScript.OnEnemyReachedTargetDoor += OnEnemyReachedTargetDoor;
    }

    private void OnEnemyReachedTargetDoor()
    {
        var liveIndex = _livesCount - 1;
        
        if (liveIndex == 0)
        {
            _lives[liveIndex].sprite = _emptyHeart;
            _gameLogic.GameOver();
            return;
        }
        
        _lives[liveIndex].sprite = _emptyHeart;
        
        _livesCount -= 1;
        _enterDoorCollisionScript.OnEnemyReachedTargetDoor -= OnEnemyReachedTargetDoor;
    }
}
