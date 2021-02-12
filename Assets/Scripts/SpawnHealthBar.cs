using UnityEngine;

public class SpawnHealthBar : MonoBehaviour
{
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private RectTransform targetCanvas;
    
    private HealthBar _healthBar;
    
    private void Start()
    {
        var healthBarObject = Instantiate(healthBarPrefab);
        
        _healthBar = healthBarObject.GetComponent<HealthBar>();
        _healthBar.SetHealthBarData(playerTransform, targetCanvas);

        gameObject.GetComponent<HealthBarController>().HealthBar = _healthBar;
    }
}
