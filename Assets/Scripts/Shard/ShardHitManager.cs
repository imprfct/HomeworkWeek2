using Assets.Scripts.Utils;
using UI.HealthBar;
using UnityEngine;

public class ShardHitManager : MonoBehaviour
{
    public float MinDamage;
    public float MaxDamage;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(GlobalConstants.EnemyTag))
        {
            var damage = Random.Range(MinDamage, MaxDamage);
            other.collider.GetComponent<HealthBarController>().TakeDamage(damage);
        }
    }
}
