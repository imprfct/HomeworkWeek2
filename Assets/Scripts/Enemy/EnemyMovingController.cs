using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovingController : MonoBehaviour
{
    public bool IsMoving { get; set; }
    public bool IsAlive { get; set; } = true;
    
    [SerializeField]
    private NavMeshAgent _agent;

    // Шанс того, что враг побежит на выход, а не будет патрулировать между рандомными позициями
    [SerializeField] 
    private float _chanceToRunToTheExit = 0.5f;
    [SerializeField] 
    private Vector3 _enemyTarget = new Vector3(25, 0, 0);
    
    [SerializeField]
    private TerrainPointProvider _pointProvider;
    
    private void Update()
    {
        if (!IsAlive)
            _agent.speed = 0;
        
        if (NeedsNewTarget() && IsAlive)
            SetNewTarget();
    }

    private bool NeedsNewTarget()
    {
        if (!_agent.hasPath)
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
            _agent.SetDestination(_enemyTarget);
        }
        else
        {
            _agent.SetDestination(_pointProvider.GetPoint());
        }
    }

    private bool EnemyWillBeTheOne()
    {
        return Random.Range(0, 1) < _chanceToRunToTheExit;
    }
}
