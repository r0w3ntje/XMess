using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health, maxHealth;

    [SerializeField] private float moveSpeed;

    private float xDir;

    public int damage;

    private Rigidbody2D rb2d;
    private Animator ac;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ac = GetComponent<Animator>();

        health = maxHealth;
    }

    private void Update()
    {
        Movement();

        if (PlayerHealth.Instance().isDead)
            Destroy(gameObject);

        if (transform.position.y < -32f)
        {
            Dead();
        }
    }

    private void Movement()
    {
        if (Player.Instance().transform.position.x > transform.position.x + 0.3f)
        {
            ac.SetBool("Walk", true);
            xDir = 1;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        else if (Player.Instance().transform.position.x < transform.position.x - 0.3f)
        {
            ac.SetBool("Walk", true);
            xDir = -1;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else
        {
            ac.SetBool("Walk", false);
            return;
        }

        rb2d.velocity = new Vector2(xDir * moveSpeed * Time.deltaTime, rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= collision.GetComponent<Bullet>().damage;

            Destroy(collision.gameObject);

            if (health <= 0)
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
        EnemySpawnManager.Instance().NextWaveCheck();
    }
}