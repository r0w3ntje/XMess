using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;

public class Player : Singleton<Player>
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
        Movement();
    }

    private void Movement()
    {
        if (Input.GetKey(Controls.Instance().left) || Input.GetKey(Controls.Instance().right))
        {
            if (Input.GetKey(Controls.Instance().left))
            {
                rb2d.velocity = new Vector2(-moveSpeed * Time.deltaTime, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(moveSpeed * Time.deltaTime, rb2d.velocity.y);
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(Controls.Instance().jump) && IsGrounded())
        {
            rb2d.velocity = new Vector2(0f, 0f);
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), groundCheckRadius, groundLayer);
    }
}