using UnityEngine;

public class Bonus : MonoBehaviour
{
    protected GameObject Player;

    public virtual void Effect(GameObject target)
    {
        Player = target;
    }
}
