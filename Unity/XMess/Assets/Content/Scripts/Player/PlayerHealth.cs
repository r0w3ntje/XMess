using System.Collections;
using System.Collections.Generic;
using Systems.Singleton;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int health, maxHealth;

    public bool isDead;

    [SerializeField] private List<GameObject> hearts;

    private void Start()
    {
        isDead = false;
        health = maxHealth;
        UpdateHealthUI();
    }

    private void TakeDamage(int _amount)
    {
        health -= _amount;

        if (health <= 0)
        {
            Dead();
        }

        UpdateHealthUI();
    }

    private void Update()
    {
        if (isDead && Input.GetButtonDown("Restart"))
        {
            Restart();
        }

        if (transform.position.y < -32f)
        {
            Dead();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            TakeDamage(collision.transform.GetComponent<Enemy>().damage);
        }
    }

    private void Dead()
    {
        isDead = true;
        UserInterfaceManager.Instance().GameOverScreen(true);
    }

    private void Restart()
    {
        isDead = false;
        UserInterfaceManager.Instance().GameOverScreen(false);
        EnemySpawnManager.Instance().Start();
        Player.Instance().Respawn();
        Start();
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(true);
        }

        for (int i = health; i < hearts.Count; i++)
        {
            hearts[i].SetActive(false);
            UserInterfaceManager.Instance().PopEffect(hearts[i].transform);
        }
    }
}