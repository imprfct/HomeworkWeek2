using Assets.Scripts.Utils;
using UnityEngine;

namespace Shard
{
    public class ShardBounceManager : MonoBehaviour
    {
        [SerializeField] 
        private float _maxBouncesCount = 3;
        private float _bouncesCount;
    
        private void Update()
        {
            if(_bouncesCount >= _maxBouncesCount)
                Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag(GlobalConstants.BordersOfMapTag))
            {
                Destroy(gameObject);
                return;
            }

            if (other.collider.CompareTag(GlobalConstants.WallsTag))
                _bouncesCount++;
        }

    }
}
