using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [NonSerialized] public bool isRunning;

    [SerializeField] private PlayerJoystickController _joystickController;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] public float _speed = 7;
    
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var inputDirection = _joystickController._inputDirection;
        if (inputDirection.Equals(Vector2.zero))
        {
            isRunning = false;
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            var direction = new Vector3(inputDirection.x, 0, inputDirection.y);
            _rigidbody.velocity = direction * _speed;
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            isRunning = true;
        }
    }
}
