using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private TerrainData terrain;
    
    private const float newEnemyCooldown = 5;
    private float _elapsed;
    
    private float _terrainSizeX, _terrainSizeZ;
    private const float OffsetFromTerrainEdges = 17f;

    private void Start()
    {
        _terrainSizeX = terrain.size.x;
        _terrainSizeZ = terrain.size.z;
    }

    private void Update()
    {
        _elapsed += Time.deltaTime;
        
        if(cooldownExpired())
            SpawnEnemy();
        
        _elapsed %= newEnemyCooldown;
    }

    private bool cooldownExpired()
    {
        if (_elapsed < newEnemyCooldown)
            return false;

        return true;
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, getRandomPosition(), Quaternion.identity);
    }

    private Vector3 getRandomPosition()
    {
        var x = Random.Range(0 + OffsetFromTerrainEdges, _terrainSizeX - OffsetFromTerrainEdges);
        var y = 0f;
        var z = Random.Range(0, _terrainSizeZ);

        return new Vector3(x, y, z);
    }
}
