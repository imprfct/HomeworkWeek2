using UnityEngine;
using UnityEngine.Serialization;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyMovingController enemy;
    [SerializeField] private HealthBarController healthBarController;
    
    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Death = Animator.StringToHash("Death");
    
    void Update()
    {
        if (Running())
            animator.SetBool(IsRunning, true);

        if (healthBarController.IsDead())
        {
            animator.SetBool(IsRunning, false);
            animator.SetTrigger(Death);
        }
            
    }

    private bool Running()
    {
        if (enemy.isMoving)
            return true;

        return false;
    }
}
