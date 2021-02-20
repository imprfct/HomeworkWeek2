using UnityEngine;
using Random = UnityEngine.Random;

public class TerrainPointProvider : MonoBehaviour
{
    public static TerrainPointProvider Instance { get; private set; }

    [SerializeField] 
    private TerrainData _terrain;
    [SerializeField]
    private float _offsetFromTerrainEdges = 35f;

    private void Awake()
    {
        Instance = this;
    }

    public Vector3 GetPoint()
    {
        var x = Random.Range(_offsetFromTerrainEdges, _terrain.size.x - _offsetFromTerrainEdges);
        var y = 0f;
        var z = Random.Range(_offsetFromTerrainEdges, _terrain.size.z - _offsetFromTerrainEdges);
        
        return new Vector3(x, y, z);
    }
}
