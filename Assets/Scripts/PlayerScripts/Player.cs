using UI.HealthBar;
using UnityEngine;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        public PlayerMovementController MovementController;
        public PlayerAnimationController AnimationController;
        public PlayerShootingController ShootingController;
        public HealthBarController HealthBarController;

        public Animator Animator;
    }
}
