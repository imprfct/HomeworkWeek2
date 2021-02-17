using UnityEngine;

public class SpawnHealthBar : MonoBehaviour
{
    [SerializeField] 
    private GameObject _healthBarPrefab;
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private RectTransform _targetCanvas;
    
    private HealthBar _healthBar;
    
    private void Start()
    {
        var healthBarObject = Instantiate(_healthBarPrefab);
        
        _healthBar = healthBarObject.GetComponent<HealthBar>();
        _healthBar.SetHealthBarData(_playerTransform, _targetCanvas);

        gameObject.GetComponent<HealthBarController>().HealthBar = _healthBar;
    }
}
