using System;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerJoystickController joystickController;
    [SerializeField] private float speed;

    [NonSerialized] public bool isRunning;

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var inputDirection = joystickController.inputDirection;
        if (inputDirection.Equals(Vector2.zero))
        {
            isRunning = false;
        }
        else
        {
            var player = transform;
            var newPosition = player.position;
            
            newPosition.x += inputDirection.x * speed * Time.deltaTime;
            newPosition.z += inputDirection.y * speed * Time.deltaTime;
            
            player.LookAt(newPosition);
            player.position = newPosition;
            isRunning = true;
        }
    }

    public bool IsPlayerRunning()
    {
        return isRunning;
    } 
}
