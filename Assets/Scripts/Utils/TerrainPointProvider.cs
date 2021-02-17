using UnityEngine;

public class TerrainPointProvider : MonoBehaviour
{
    [SerializeField] 
    private TerrainData _terrain;
    [SerializeField]
    private float _offsetFromTerrainEdges = 35f;
    
    public Vector3 GetPoint()
    {
        var x = Random.Range(_offsetFromTerrainEdges, _terrain.size.x - _offsetFromTerrainEdges);
        var y = 0f;
        var z = Random.Range(_offsetFromTerrainEdges, _terrain.size.z - _offsetFromTerrainEdges);
        
        return new Vector3(x, y, z);
    }
}
