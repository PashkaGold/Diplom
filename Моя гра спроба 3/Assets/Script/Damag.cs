using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Damag : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTagTree;
    public string collisionTagStone;
    public string collisionTagMob;
    public string knockbackTag; // Тег об'єкта, який потрібно відкинути
    public float knockbackForce = 10f; // Сила відкидання
    public TMP_Text GoldText;


    public void ChangeKnockback()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            float count = 1f;
            knockbackForce += count;
        }
    }
    public void ChangeDamage()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            collisionDamage += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        // Перевірка на нанесення урону
        if (coll.gameObject.tag == collisionTagTree || coll.gameObject.tag == collisionTagStone || coll.gameObject.tag == collisionTagMob)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeHit(collisionDamage);
            }
        }


        // Перевірка на відкидання
        if (coll.gameObject.tag == knockbackTag)
        {
            Rigidbody2D rb = coll.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 knockbackDirection = (coll.transform.position - transform.position).normalized;
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }
}