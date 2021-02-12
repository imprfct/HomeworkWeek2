using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyMovingController enemy;

    private static readonly int IsRunning = Animator.StringToHash("isRunning");
    private static readonly int Death = Animator.StringToHash("Death");
    
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

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Shard"))
            KillEnemy();
    }

    private void KillEnemy()
    {
        enemy.isAlive = false;
        enemy.isMoving = false;
        
        animator.SetBool(IsRunning, false);
        animator.SetTrigger(Death);

        var healthBar = enemy.GetComponent<EnemyHealthBarController>().healthBar;
    
        healthBar.SetHealthInPercents(0f);
        
        Destroy(healthBar.gameObject, 0.5f);
        Destroy(gameObject, 0.5f);
    }
}
