using UnityEngine;

public class TerrainPointProvider : MonoBehaviour
{
    [SerializeField] private TerrainData terrain;
    [SerializeField] private float offsetFromTerrainEdges = 17f;
    
    public Vector3 getRandomPosition()
    {
        var x = Random.Range(offsetFromTerrainEdges, terrain.size.x - offsetFromTerrainEdges);
        var y = 0f;
        var z = Random.Range(offsetFromTerrainEdges, terrain.size.z - offsetFromTerrainEdges);
        
        return new Vector3(x, y, z);
    }
}
