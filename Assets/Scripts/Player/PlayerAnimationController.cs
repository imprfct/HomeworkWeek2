using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;
    [SerializeField] 
    private PlayerMovementController _movementController;
    [SerializeField]
    private PlayerShootingController _shootingController;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Attack = Animator.StringToHash("isAttackingWithFirstAnimation");

    private void Update()
    {
        if (_movementController.isRunning)
        {
            _animator.ResetTrigger(Attack);            
            _animator.SetBool(IsRunning, true);
        }
        else if(_shootingController.CouldAttackEnemy())
        {
            _animator.SetBool(IsRunning, false);
            _animator.SetTrigger(Attack);
        }
        else
        {
            _animator.ResetTrigger(Attack);
            _animator.SetBool(IsRunning, false);
        }
    }
}
