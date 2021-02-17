using UnityEngine;

public class HealthPointsBonus : Bonus
{
    [SerializeField] 
    private float _healthToAdd = 25f;

    public override void Effect(GameObject player)
    {
        base.Effect(player);
        Player.GetComponent<HealthBarController>().MaxHealthPoints += _healthToAdd;
        Player.GetComponent<HealthBarController>().CurrentHealthPoints += _healthToAdd;
        
        Debug.Log("Added HP to player");
    }
}
