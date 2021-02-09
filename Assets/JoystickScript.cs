using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Assets
{
    public class JoystickScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        [SerializeField] private Image joystickBackgroundImage;
        [SerializeField] private Image joystickImage;
        [SerializeField] private float offset; 

        [HideInInspector] public Vector2 inputDirection;

        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            inputDirection = Vector2.zero;
            joystickImage.rectTransform.anchoredPosition = inputDirection;
        }

        public void OnDrag(PointerEventData eventData)
        {
            float backgroundImageSizeX = joystickBackgroundImage.rectTransform.sizeDelta.x;
            float backgroundImageSizeY = joystickBackgroundImage.rectTransform.sizeDelta.y;
            
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackgroundImage.rectTransform,
                eventData.position, eventData.pressEventCamera, out var position))
            {
                position.x /= backgroundImageSizeX;
                position.y /= backgroundImageSizeY;
                
                inputDirection = new Vector2(position.x, position.y);
                inputDirection = inputDirection.magnitude > 1 ? inputDirection.normalized : inputDirection;
                
                joystickImage.rectTransform.anchoredPosition = new 
                    Vector2(inputDirection.x * (backgroundImageSizeX / offset),
                    inputDirection.y * (backgroundImageSizeY / offset));
            }
        }
    }
}
