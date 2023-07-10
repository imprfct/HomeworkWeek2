using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerJoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [HideInInspector]
        public Vector2 _inputDirection;

        [SerializeField]
        private Image _joystickBackgroundImage;
        [SerializeField]
        private Image _joystickImage;
        [SerializeField]
        private float _offset; 

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }
    
        public void OnDrag(PointerEventData eventData)
        {
            var sizeDelta = _joystickBackgroundImage.rectTransform.sizeDelta;
            float backgroundImageSizeX = sizeDelta.x;
            float backgroundImageSizeY = sizeDelta.y;
            
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackgroundImage.rectTransform,
                eventData.position, eventData.pressEventCamera, out var position))
            {
                position.x /= backgroundImageSizeX;
                position.y /= backgroundImageSizeY;
                
                _inputDirection = new Vector2(position.x, position.y);
                _inputDirection = _inputDirection.magnitude > 1 ? _inputDirection.normalized : _inputDirection;
                
                _joystickImage.rectTransform.anchoredPosition = new 
                    Vector2(_inputDirection.x * (backgroundImageSizeX / _offset),
                        _inputDirection.y * (backgroundImageSizeY / _offset));
            }
        }
    
        public void OnPointerUp(PointerEventData eventData)
        {
            _inputDirection = Vector2.zero;
            _joystickImage.rectTransform.anchoredPosition = _inputDirection;
        }
    }
}