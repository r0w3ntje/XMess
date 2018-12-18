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

    public bool isDead;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        isDead = false;
    }

    private void Update()
    {
        Jump();
        Movement();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(x * moveSpeed * Time.deltaTime, rb2d.velocity.y);

        if (x < 0)
            transform.localScale = new Vector2(-1, transform.localScale.y);
        else if (x > 0)
            transform.localScale = new Vector2(1, transform.localScale.y);


        //if (Input.GetKey(Controls.Instance().left) || Input.GetKey(Controls.Instance().right))
        //{
        //    if (Input.GetKey(Controls.Instance().left))
        //    {
        //        rb2d.velocity = new Vector2(-moveSpeed * Time.deltaTime, rb2d.velocity.y);
        //        transform.localScale = new Vector2(-1, transform.localScale.y);
        //    }
        //    else
        //    {
        //        rb2d.velocity = new Vector2(moveSpeed * Time.deltaTime, rb2d.velocity.y);
        //        transform.localScale = new Vector2(1, transform.localScale.y);
        //    }
        //}
        //else
        //{
        //    rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        //}
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
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