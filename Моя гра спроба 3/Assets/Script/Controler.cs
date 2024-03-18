using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float attackRange = 1.5f;
    public Rigidbody2D rb;
    private Vector2 direction;
    public Animator animator;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Отримуємо вхідні дані для руху
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        // Рухаємо персонажа
        Vector2 movement = new Vector2(direction.x, direction.y).normalized;
        rb.velocity = movement * moveSpeed;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        // Провіряємо, чи гравець натиснув клавішу атаки (наприклад, пробіл)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Викликаємо метод для виконання атаки
            Attack();
        }

    }


    void Attack()
    {
        // Провіряємо, чи є об'єкти в атакованому діапазоні
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            // Тут можна здійснювати дійсні дії атаки, наприклад, зменшувати здоров'я ворога.
            // Наприклад, enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    // Малюємо границі атаки для візуалізації
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void FixedUpdate()
    {

    }
}
