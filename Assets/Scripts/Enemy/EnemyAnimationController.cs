using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;
    
    [SerializeField] 
    private EnemyMovingController _enemy;
    
    [SerializeField] 
    private HealthBarController _healthBarController;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Death = Animator.StringToHash("Death");
    
    void Update()
    {
        if (Running())
            _animator.SetBool(IsRunning, true);

        if (_healthBarController.IsDead())
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetTrigger(Death);
        }
    }

    private bool Running()
    {
        if (_enemy.IsMoving)
            return true;

        return false;
    }
}
