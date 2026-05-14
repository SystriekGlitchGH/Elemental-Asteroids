using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D rb2d;
    public Transform gravitySource;
    [Header("Movement")]
    public float acceleration;
    public float maxSpeed;
    public float friction;
    private float directionX, directionY;
    private void FixedUpdate()
    {
        // adding acceleration to the directions
        Vector2 newVelocity = new Vector2(directionX * acceleration, directionY * acceleration);
        // adding the force to the rigidbody2d
        rb2d.AddRelativeForce(newVelocity);
        // maxing the velocity of the player to the playerStats.baseSpeed variable
        Vector2 velocity = Vector2.ClampMagnitude(new Vector2(rb2d.linearVelocity.x, rb2d.linearVelocity.y), maxSpeed);
        // applying clamped velocity to rigidbody2d
        rb2d.linearVelocity = velocity;
        // when both direction inputs are 0, add linear damping to slow down player quickly
        if (directionX == 0 && directionY == 0) rb2d.linearDamping = friction;
        else rb2d.linearDamping = 0;
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        directionX = ctx.ReadValue<Vector2>().x;
        directionY = ctx.ReadValue<Vector2>().y;
    }
}
