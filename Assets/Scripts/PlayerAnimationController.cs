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
        if(movementController.IsPlayerRunning())
            animator.SetBool(IsRunning, true);
        else
        {
            animator.SetBool(IsRunning, false);
            animator.SetBool(Attack, true);
        }
    }
}
