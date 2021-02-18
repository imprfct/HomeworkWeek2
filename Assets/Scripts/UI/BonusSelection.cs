using UnityEngine;
using UnityEngine.EventSystems;

public class BonusSelection : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        var selectedBonus = eventData.pointerClick.GetComponent<BonusSetter>();
        selectedBonus.Bonus.Effect(GameObject.FindGameObjectWithTag("Player"));

        var bonusPanel = transform.parent.gameObject;
        Destroy(bonusPanel);
        
        Time.timeScale = 1;
    }
}
