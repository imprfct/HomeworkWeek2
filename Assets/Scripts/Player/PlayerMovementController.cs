using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [NonSerialized] public bool isRunning;

    [SerializeField] private PlayerJoystickController _joystickController;
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
        }
        else
        {
            var player = transform;
            var newPosition = player.position;
            
            newPosition.x += inputDirection.x * _speed * Time.deltaTime;
            newPosition.z += inputDirection.y * _speed * Time.deltaTime;
            
            player.LookAt(newPosition);
            player.position = newPosition;
            isRunning = true;
        }
    }
}
