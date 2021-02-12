using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerShootingController shootingController;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Attack = Animator.StringToHash("isAttackingWithFirstAnimation");

    private void Update()
    {
        if (movementController.IsPlayerRunning())
        {
            animator.ResetTrigger(Attack);            
            animator.SetBool(IsRunning, true);
        }
        else if(shootingController.PlayerMayAttackEnemy())
        {
            animator.SetBool(IsRunning, false);
            animator.SetTrigger(Attack);
        }
        else
        {
            animator.ResetTrigger(Attack);
            animator.SetBool(IsRunning, false);
        }
    }
}
