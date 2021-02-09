using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private PlayerJoystickController joystickController;
    [SerializeField] private float speed;
    
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var inputDirection = joystickController.inputDirection;
        if (!inputDirection.Equals(Vector2.zero))
        {
            var playerTransform = transform;
            var newPosition = playerTransform.position;
            
            newPosition.x = newPosition.x + inputDirection.x * speed * Time.deltaTime;
            newPosition.z = newPosition.z + inputDirection.y * speed * Time.deltaTime;

            playerTransform.position = newPosition;
        }
    }
}
