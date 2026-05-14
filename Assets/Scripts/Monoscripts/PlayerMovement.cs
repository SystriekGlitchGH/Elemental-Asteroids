using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb2d;
    [Header("Movement")]
    public float acceleration;
    public float topMovementSpeed;
    public float maxSpeed;
    public float friction;
    private float directionX, directionY;
    private void FixedUpdate()
    {
        // velocity based on accelteration and direction
        Vector2 movementVelocity = new Vector2(directionX * acceleration, directionY * acceleration);
        rb2d.AddRelativeForce(movementVelocity);
        if (movementVelocity.magnitude > topMovementSpeed)
            movementVelocity = movementVelocity.normalized * topMovementSpeed;
        Vector2 externalVelocity = rb2d.linearVelocity - movementVelocity;
        rb2d.linearVelocity = movementVelocity + externalVelocity;
        rb2d.linearVelocity = Vector2.ClampMagnitude(rb2d.linearVelocity,maxSpeed);
        Debug.Log(rb2d.linearVelocity.magnitude);
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        directionX = ctx.ReadValue<Vector2>().x;
        directionY = ctx.ReadValue<Vector2>().y;
    }
}
