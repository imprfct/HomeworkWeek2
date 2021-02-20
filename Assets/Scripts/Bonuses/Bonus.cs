using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public Sprite Image;
    public string Description;
    
    public abstract void ApplyEffect(GameObject target);
}
