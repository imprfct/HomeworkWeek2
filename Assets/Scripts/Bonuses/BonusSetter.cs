using UnityEngine;
using UnityEngine.UI;

public class BonusSetter : MonoBehaviour
{
    [SerializeField]
    private Image _image;
    [SerializeField]
    private Text _description;
    [SerializeField]
    public Bonus Bonus;
    
    public void SetBonus(Bonus bonus)
    {
        _image.sprite = bonus._bonusImage;
        _description.text = bonus._bonusDescription;
        Bonus = bonus;
    } 
}
