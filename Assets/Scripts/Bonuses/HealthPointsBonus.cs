using UnityEngine;

public class HealthPointsBonus : Bonus
{
    [SerializeField] 
    private float _healthToAdd = 25f;

    public override void Effect(GameObject player)
    {
        base.Effect(player);

        var healthBarController = Player.GetComponent<HealthBarController>();
        healthBarController.MaxHealthPoints += _healthToAdd;
        healthBarController.CurrentHealthPoints += _healthToAdd;
        
        Debug.Log("Added HP to player");
    }
}
