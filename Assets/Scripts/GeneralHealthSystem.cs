using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralHealthSystem : MonoBehaviour
{
    private int _livesCount;

    [SerializeField] private List<Image> lives;
    [SerializeField] private Sprite emptyHeart;
    
    [SerializeField] private CollisionsWithDoors enterDoorCollisionScript;
    [SerializeField] private GameLogic gameLogic;
    
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
            lives[liveIndex].sprite = emptyHeart;
            gameLogic.GameOver();
            return;
        }
        
        lives[liveIndex].sprite = emptyHeart;
        
        _livesCount -= 1;
    }
}
