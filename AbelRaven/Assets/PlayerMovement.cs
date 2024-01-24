using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust this to set the movement speed
    public float jumpForce = 10f; // Adjust this to set the jump force

    private bool isGrounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is grounded (you may need to adjust the 'Ground' layer or use a more complex check)
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.8f, LayerMask.GetMask("Ground"));

        // Log the grounded status for debugging
        Debug.Log("Grounded: " + isGrounded);

        // Get input for horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the GameObject horizontally
        Vector2 movement = new Vector2(horizontalInput, 0f);
        transform.Translate(movement * speed * Time.deltaTime);

        // Check for jump input and if the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Apply upward force for jumping
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        // Log the jump for debugging
        Debug.Log("Jumping");
    }
}