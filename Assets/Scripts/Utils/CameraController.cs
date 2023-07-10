using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    private Transform _target;
    
    [SerializeField] 
    private float _smoothSpeed = 0.8f;
    
    [SerializeField] 
    private Vector3 _offset = new Vector3(0, -10, -5);
    
    private void LateUpdate()
    {
        Vector3 desiredPosition = _target.position + _offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,
            desiredPosition, _smoothSpeed * Time.deltaTime);
        
        transform.position = smoothedPosition;
    }
}
