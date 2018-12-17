using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;

    [SerializeField] private float moveSpeed;

    private float xDir;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Player.Instance().transform.position.x > transform.position.x + 0.3f)
        {
            xDir = 1;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (Player.Instance().transform.position.x < transform.position.x - 0.3f)
        {
            xDir = -1;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else
        {
            return;
        }

        rb2d.velocity = new Vector2(xDir * moveSpeed * Time.deltaTime, rb2d.velocity.y);
    }
}