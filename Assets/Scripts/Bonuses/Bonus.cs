using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Sprite _bonusImage;
    public string _bonusDescription;
    
    protected GameObject Player;

    public virtual void Effect(GameObject target)
    {
        Player = target;
    }
}
