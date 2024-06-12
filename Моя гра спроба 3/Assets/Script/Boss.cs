using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth = 1000;
    private int currentHealth;

    public int attackDamage = 50;
    public float attackRange = 2f;
    public float attackRate = 1f;
    private float nextAttackTime = 0f;

    public Transform player;
    public LayerMask playerLayer;

    public float speed = 3f;
    public float stoppingDistance = 2f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform is not assigned.");
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (Time.time >= nextAttackTime && distanceToPlayer <= attackRange)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }

        if (distanceToPlayer > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
        foreach (Collider2D hitPlayer in hitPlayers)
        {
            PlayerHealth playerHealth = hitPlayer.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
            }
            else
            {
                Debug.LogWarning("PlayerHealth component not found on target.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Додайте логіку смерті боса, наприклад, анімацію смерті
        Destroy(gameObject);
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
