using UnityEngine;

public class HealthPointsBonus : Bonus
{
    [SerializeField] 
    private float _healthToAdd = 25f;

    public override void ApplyEffect(GameObject player)
    {
        var healthBarController = player.GetComponent<HealthBarController>();
        healthBarController.MaxHealthPoints += _healthToAdd;
        healthBarController.CurrentHealthPoints += _healthToAdd;
    }
}
