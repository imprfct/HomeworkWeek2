using UnityEngine;
using UnityEngine.AI;

public class EnemyMovingController : MonoBehaviour
{
    public bool IsMoving { get; set; }
    public bool IsAlive { get; set; } = true;

    // Шанс того, что враг побежит на выход, а не будет патрулировать между рандомными позициями
    [SerializeField] private float chanceToBeTheOne = 0.5f;
    [SerializeField] private Vector3 enemyTarget = new Vector3(25, 0, 0);
    
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private TerrainPointProvider pointProvider;
    
    private void Update()
    {
        if (NeedsNewTarget() && IsAlive)
        {
            SetNewTarget();
        }
    }

    private bool NeedsNewTarget()
    {
        if (!agent.hasPath)
        {
            IsMoving = false;
            return true;
        }

        return false;
    }

    private void SetNewTarget()
    {
        IsMoving = true;

        if (EnemyWillBeTheOne())
        {
            agent.SetDestination(enemyTarget);
        }
        else
        {
            agent.SetDestination(pointProvider.GetPoint());
        }
    }

    private bool EnemyWillBeTheOne()
    {
        return Random.Range(0, 1) < chanceToBeTheOne;
    }
}
