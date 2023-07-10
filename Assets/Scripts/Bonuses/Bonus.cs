using PlayerScripts;
using UnityEngine;

namespace Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        public Sprite Image;
        public string Description;
    
        public abstract void ApplyEffect(Player target);
    }
}
