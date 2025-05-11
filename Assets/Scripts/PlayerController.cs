using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (movementJoystick.joystickVec != Vector2.zero)
        {
            Vector2 moveDirection = movementJoystick.joystickVec.normalized;
            rb.linearVelocity = moveDirection * playerSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
