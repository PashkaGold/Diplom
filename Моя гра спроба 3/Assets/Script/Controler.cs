using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        // �������� ������ ���� ��� ����
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        // ������ ���������
        Vector2 movement = new Vector2(direction.x, direction.y).normalized;
        rb.velocity = movement * moveSpeed;
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        // ���������, �� ������� �������� ������ ����� (���������, �����)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ��������� ����� ��� ��������� �����
            Attack();
        }

    }
    public TMP_Text GoldText;

    public void ChangeSpeed()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            var multiplier = moveSpeed * 0.1f;
            moveSpeed += multiplier; // �������� �������� �� ������ �������
        }
    }
    public void Attack()
    {
        // ���������, �� � ��'���� � ����������� ��������
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D enemy in hitEnemies)
        {
            // ��� ����� ���������� ����� 䳿 �����, ���������, ���������� ������'� ������.
            // ���������, enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    // ������� ������� ����� ��� ����������
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    private void FixedUpdate()
    {

    }

}