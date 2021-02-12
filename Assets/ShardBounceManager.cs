using UnityEngine;

public class ShardBounceManager : MonoBehaviour
{
    public float maxBouncesCount = 3;
    private float _bouncesCount;

    private void Update()
    {
        if(_bouncesCount >= maxBouncesCount)
            Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BordersOfMap"))
        {
            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Walls") || other.CompareTag("Terrain"))
            _bouncesCount++;
    }
}
