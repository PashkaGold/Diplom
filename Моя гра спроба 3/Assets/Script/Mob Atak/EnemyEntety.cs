using System;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class EnemyEntity : MonoBehaviour
{
    public event EventHandler OnTakeHit;
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Приклад: нанесення урону 10 одиниць
                OnTakeHit?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        OnTakeHit?.Invoke(this, EventArgs.Empty);
        DetectDeath();
    }

    public void PolygonColliderTurnOff()
    {
        _polygonCollider2D.enabled = false;
    }

    public void PolygonColliderTurnOn()
    {
        _polygonCollider2D.enabled = true;
    }

    private void DetectDeath()
    {
        if (_currentHealth <= 0)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Destroy(gameObject);
        }
    }
}
