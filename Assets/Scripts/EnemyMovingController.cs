using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovingController : MonoBehaviour
{
    public bool isMoving { get; set; }
    public bool isAlive { get; set; } = true;
    
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private TerrainPointProvider pointProvider;
    
    private void Update()
    {
        if (NeedsNewTarget() && isAlive)
        {
            SetNewTarget();
        }
    }

    private bool NeedsNewTarget()
    {
        if (!agent.hasPath)
        {
            isMoving = false;
            return true;
        }

        return false;
    }

    private void SetNewTarget()
    {
        isMoving = true;
        agent.SetDestination(pointProvider.getRandomPosition());
    }
}
