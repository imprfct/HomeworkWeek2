using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovementController movementController;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    private void Update()
    {
        animator.SetBool(IsRunning, movementController.IsPlayerRunning());
    }
}
