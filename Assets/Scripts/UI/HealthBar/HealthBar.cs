using UnityEngine;

namespace UI.HealthBar
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private float _healthBarOffsetY = -20f; 
        private Camera _camera;
        private RectTransform _targetCanvas;
        private RectTransform _healthBar;
        private Transform _objectToFollow;
        private RectTransform _healthBarTransform;

        public void SetHealthBarData(Transform targetTransform, RectTransform healthBarPanel)
        {
            _camera = Camera.main;
            _targetCanvas = healthBarPanel;
            _healthBar = GetComponent<RectTransform>();
            _objectToFollow = targetTransform;

            RepositionHealthBar();
            transform.SetParent(_targetCanvas);
            _healthBar.gameObject.SetActive(true);
        
            _healthBarTransform = _healthBar.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        }
    
        public void SetHealthInPercents(float healthPercent)
        {
            _healthBarTransform.localScale = new Vector3(healthPercent, 1, 1);
        }
    
        void Update()
        {
            RepositionHealthBar();
        }
    
        private void RepositionHealthBar()
        {        
            var canvasSizeDelta = _targetCanvas.sizeDelta;
        
            Vector2 viewportPosition = _camera.WorldToViewportPoint(_objectToFollow.position);
            Vector2 worldObjectScreenPosition = new Vector2(
                ((viewportPosition.x * canvasSizeDelta.x) - (canvasSizeDelta.x * 0.5f)),
                ((viewportPosition.y * canvasSizeDelta.y) - (canvasSizeDelta.y * 0.5f)) + _healthBarOffsetY);
            _healthBar.anchoredPosition = worldObjectScreenPosition;
        }
    }
}