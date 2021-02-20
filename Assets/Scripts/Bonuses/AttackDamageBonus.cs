using UnityEngine;

public class AttackDamageBonus : Bonus
{
    [SerializeField] 
    private float _damageToAdd = 25f;
    
    public override void ApplyEffect(GameObject player)
    {
        var shootingController = player.GetComponent<PlayerShootingController>();
        shootingController.minDamage += _damageToAdd;
        shootingController.maxDamage += _damageToAdd;
    }
}