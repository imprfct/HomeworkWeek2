using UnityEngine;

public class AttackDamageBonus : Bonus
{
    [SerializeField] 
    private float _damageToAdd = 25f;
    
    public override void Effect(GameObject player)
    {
        base.Effect(player);
        
        var shootingController = Player.GetComponent<PlayerShootingController>();
        shootingController.minDamage += _damageToAdd;
        shootingController.maxDamage += _damageToAdd;
        
        Debug.Log("Added DMG to player");
    }
}