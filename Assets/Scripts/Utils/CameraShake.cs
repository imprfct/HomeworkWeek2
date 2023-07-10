using UI.HealthBar;
using UnityEngine;

namespace Utils
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField]
        private Transform _camTransform;
	
        private float _shakeDuration;
	    
        [SerializeField]
        private float _shakeAmount = 0.3f;
        [SerializeField]
        private float _decreaseFactor = 1.0f;
	    
        private Vector3 _originalPos;
        private bool _isShaking;
        
        void Awake()
        {
            HealthBarController.PlayerGotHit += ShakeCamera;
            GeneralHealthSystem.EnemyReachedTargetDoor += ShakeCamera;
        }

        private void ShakeCamera()
        {
            _isShaking = true;
            _shakeDuration = 0.3f;
        }

        void Update()
        {
            if (_isShaking)
            {
                _originalPos = _camTransform.localPosition;
                
                if (_shakeDuration > 0)
                {
                    _camTransform.localPosition = _originalPos + Random.insideUnitSphere * _shakeAmount;
                    _shakeDuration -= Time.deltaTime * _decreaseFactor;
                }
                else
                {
                    _shakeDuration = 0f;
                    _camTransform.localPosition = _originalPos;
                    _isShaking = false;
                }
            }
        }
    }
}