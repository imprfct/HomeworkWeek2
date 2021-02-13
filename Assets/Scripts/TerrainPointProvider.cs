using UnityEngine;

public class TerrainPointProvider : MonoBehaviour
{
    [SerializeField] private TerrainData terrain;
    [SerializeField] private float offsetFromTerrainEdges = 35f;
    
    public Vector3 GetPoint()
    {
        var x = Random.Range(offsetFromTerrainEdges, terrain.size.x - offsetFromTerrainEdges);
        var y = 0f;
        var z = Random.Range(offsetFromTerrainEdges, terrain.size.z - offsetFromTerrainEdges);
        
        return new Vector3(x, y, z);
    }
}
