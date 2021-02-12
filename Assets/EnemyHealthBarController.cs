using UnityEngine;

public class EnemyHealthBarController : MonoBehaviour
{
    public HealthBar healthBar;

    public void SetHealthBar(HealthBar healthBar_)
    {
        healthBar = healthBar_;
    }
}