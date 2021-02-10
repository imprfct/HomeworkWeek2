using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyMovingController enemy;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    void Update()
    {
        if (Running())
            animator.SetBool(IsRunning, true);
    }

    private bool Running()
    {
        if (enemy.isMoving)
            return true;

        return false;
    }
}
