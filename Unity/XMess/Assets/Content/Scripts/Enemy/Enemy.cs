using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;

    [SerializeField] private float moveSpeed;

    private float xDir;

    public int damage;

    private Rigidbody2D rb2d;
    private Animator ac;

    [SerializeField] private GameObject deathParticle;

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
            ac.SetTrigger("Hit");

            CameraShake.Instance().Shake(0.25f, 0.15f);

            Destroy(collision.gameObject);

            if (health <= 0)
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
<<<<<<< HEAD
        SoundManager.Instance().PlayDemonDeath();
=======
        GameObject dp = Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(dp, 0.5f);

>>>>>>> 5c766dc28fd482e3f62be6aa72266039fe1c5723
        Destroy(gameObject);
        EnemySpawnManager.Instance().NextWaveCheck();
    }
}