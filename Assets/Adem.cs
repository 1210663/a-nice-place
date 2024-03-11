using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotocharacter : MonoBehaviour
{
    public float jumpForce = 10f;
    // Speed of movement
    public float moveSpeed = 5f;
    // Number of times to perform the custom action
    public int actionCount = 3;

    //Reference to the Rigidbody
    private Rigidbody2D rb;

    // Whether the character is currently grounded
    private bool isGrounded;
    // Whether the character is currently blocking
    private bool isBlocking;

    // List of custom actions
    private List<string> customActions = new List<string> { "Action1", "Action2", "Action3" };

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // Example initialization code
        Debug.Log("Character initialized.");
        isGrounded = true; // Assume the character starts on the ground
        isBlocking = false; // Assume the character is not blocking initially
    }

    void FixedUpdate()
    {
        // Horizontal movement
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
  
    // Update is called once per frame
    void Update()
    {
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

        // Perform custom action
        PerformCustomAction();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Custom function to perform an action multiple times
    private void PerformCustomAction()
    {
        // For loop to perform the action multiple times
        for (int i = 0; i < actionCount; i++)
        {
            Debug.Log("Performing action " + (i + 1));
        }

        // While loop to perform the action while a condition is met
        int index = 0;
        while (index < customActions.Count)
        {
            Debug.Log("Performing custom action: " + customActions[index]);
            index++;
        }
    }
}