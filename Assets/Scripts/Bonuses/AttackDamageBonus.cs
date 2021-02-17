using UnityEngine;

public class AttackDamageBonus : Bonus
{
    [SerializeField] 
    private float _damageToAdd = 25f;

    public override void Effect(GameObject player)
    {
        base.Effect(player);
        Player.GetComponent<PlayerShootingController>().minDamage += _damageToAdd;
        Player.GetComponent<PlayerShootingController>().maxDamage += _damageToAdd;
        
        Debug.Log("Added DMG to player");
    }
}