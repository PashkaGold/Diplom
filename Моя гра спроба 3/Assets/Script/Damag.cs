﻿using System;
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
    public string knockbackTag;
    public float knockbackForce = 10f;
    public TMP_Text GoldText;

    private void Start()
    {
        LoadPlayerPrefs();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(collisionTagTree) || coll.gameObject.CompareTag(collisionTagStone))
        {
            Health health = coll.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeHit(collisionDamage);
            }
        }
        else if (coll.gameObject.CompareTag(collisionTagMob))
        {
            EnemyEntity enemyEntity = coll.gameObject.GetComponent<EnemyEntity>();
            if (enemyEntity != null)
            {
                enemyEntity.TakeDamage(collisionDamage);
            }
        }

        if (coll.gameObject.CompareTag(knockbackTag))
        {
            Rigidbody2D rb = coll.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 knockbackDirection = (coll.transform.position - transform.position).normalized;
                rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            }
        }
    }

    public void ChangeKnockback()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            float count = 1f;
            knockbackForce += count;
            SavePlayerPrefs();
            Debug.Log("Покращення knockbackForce збережено: " + knockbackForce);
        }
    }

    public void ChangeDamage()
    {
        if (Int32.Parse(GoldText.text) >= 10)
        {
            collisionDamage += 1;
            SavePlayerPrefs();
            Debug.Log("Покращення collisionDamage збережено: " + collisionDamage);
        }
    }

    private void LoadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("CollisionDamage"))
        {
            collisionDamage = PlayerPrefs.GetInt("CollisionDamage");
            Debug.Log("Урон завантажена з PlayerPref: " + collisionDamage);
        }

        if (PlayerPrefs.HasKey("KnockbackForce"))
        {
            knockbackForce = PlayerPrefs.GetFloat("KnockbackForce");
            Debug.Log("Knockback сила завантажена з PlayerPref: " + knockbackForce);
        }
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("CollisionDamage", collisionDamage);
        PlayerPrefs.SetFloat("KnockbackForce", knockbackForce);
        PlayerPrefs.Save();
        Debug.Log("Урон та Knockback сила збережено в PlayerPref: " + collisionDamage + ", " + knockbackForce);
    }
}
