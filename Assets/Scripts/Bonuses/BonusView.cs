using PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Bonuses
{
    public class BonusView : MonoBehaviour
    {
        private Bonus _bonus;

        [SerializeField]
        private Image _image;
        [SerializeField]
        private Text _description;
    
        public void Initialize(Bonus bonus)
        {
            _image.sprite = bonus.Image;
            _description.text = bonus.Description;
            _bonus = bonus;
        }

        public void UseBonus(Player target)
        {
            _bonus.ApplyEffect(target);
        }
    }
}
