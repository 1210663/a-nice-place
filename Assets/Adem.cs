using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotocharacter : MonoBehaviour
{
    public float jumpForce = 10f;
    // Speed of movement
    public float moveSpeed = 5f;
        
    //Reference to the Rigidbody
    private Rigidbody2D rb;

    // Whether the character is currently grounded
    private bool isGrounded;
    // Whether the character is currently blocking
    private bool isBlocking;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
  
   // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // Blocking
        if (Input.GetKey(KeyCode.DownArrow))
        {
            isBlocking = true;
        }
        else
        {
            isBlocking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}