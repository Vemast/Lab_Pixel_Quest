using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    // Components
    private Rigidbody2D _rigidbody2D;

    // Velocity
    private float _xVelocity;
    private float _yVelocity;
    public float speed = 7.5f;

    // Gets the component connection
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Reset velocity
        _xVelocity = 0f;
        _yVelocity = 0f;

        // Check for specific key presses (WASD)
        if (Input.GetKey(KeyCode.W)) _yVelocity = 1f;
        if (Input.GetKey(KeyCode.S)) _yVelocity = -1f;
        if (Input.GetKey(KeyCode.A)) _xVelocity = -1f;
        if (Input.GetKey(KeyCode.D)) _xVelocity = 1f;

        // Normalize the velocity vector to maintain consistent speed
        Vector2 movement = new Vector2(_xVelocity, _yVelocity).normalized;

        // Push the input data to the Rigidbody
        _rigidbody2D.velocity = movement * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 9f;
        } else
        {
            speed = 7.5f;
        }
    }
}
