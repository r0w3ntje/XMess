using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int health, maxHealth;

    public bool isDead;

    [SerializeField] private Text healthText;

    private void Start()
    {
        isDead = false;
        health = maxHealth;
        UpdateTexts();
    }

    private void TakeDamage(int _amount)
    {
        health -= _amount;

        if (health <= 0)
        {
            isDead = true;
            UserInterfaceManager.Instance().GameOverScreen(true);
        }

        UpdateTexts();
    }

    private void Update()
    {
        if (isDead && Input.GetButton("Restart"))
        {
            Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            TakeDamage(collision.transform.GetComponent<Enemy>().damage);
        }
    }

    private void Restart()
    {
        isDead = false;
        UserInterfaceManager.Instance().GameOverScreen(true);
    }

    private void UpdateTexts()
    {
        healthText.text = "Health: " + health;
        UserInterfaceManager.Instance().PopEffect(healthText.transform);
    }
}