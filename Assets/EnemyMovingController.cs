using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMovingController : MonoBehaviour
{
    [SerializeField] private TerrainData terrain;
    [SerializeField] private NavMeshAgent agent;
    
    private Vector3 _target;
    public bool isMoving;
    
    private float _terrainSizeX, _terrainSizeZ;
    private const float OffsetFromTerrainEdges = 17f; 
    
    private void Start()
    {
        _terrainSizeX = terrain.size.x;
        _terrainSizeZ = terrain.size.z;
    }

    private void Update()
    {
        if (!isMoving || isNeedsInNewTarget())
        {
            SetNewTarget();
        }
        
        // TODO: Исправить ходьбу задом
    }

    private bool isNeedsInNewTarget()
    {
        if (agent.destination == gameObject.transform.position)
        {
            isMoving = false;
            return true;
        }

        return false;
    }

    private void SetNewTarget()
    {
        var x = Random.Range(0 + OffsetFromTerrainEdges, _terrainSizeX - OffsetFromTerrainEdges);
        var y = 0f;
        var z = Random.Range(0, _terrainSizeZ);
        
        _target =  new Vector3(x, y, z);
        isMoving = true;
        
        agent.SetDestination(_target);
    }
}
