using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BonusSelection : MonoBehaviour
{
    [SerializeField]
    private Button _bonus;

    void Start()
    {
        _bonus.onClick.AddListener(OnPointerClick);
    }
    
    private void OnPointerClick()
    {
        var selectedBonus = gameObject.GetComponent<BonusView>();
        selectedBonus.UseBonus(GameObject.FindGameObjectWithTag("Player"));

        var bonusPanel = transform.parent.gameObject;
        Destroy(bonusPanel);
        
        Time.timeScale = 1;
        
        _bonus.onClick.RemoveListener(OnPointerClick);
    }
}
