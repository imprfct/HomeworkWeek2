using UI;
using UI.HealthBar;
using UnityEngine;

namespace EnemyScripts
{
    public class Enemy : MonoBehaviour
    {
        public EnemyMovingController MovingController;
        public EnemyAnimationController AnimationController;
        public HealthBarController HealthBarController;
        public KilledEnemiesUpdater KilledEnemiesUpdater;
    }
}
