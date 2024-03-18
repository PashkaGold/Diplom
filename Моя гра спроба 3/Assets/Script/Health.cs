using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public void TakeHit(int damege)
    {
        health -= damege;
        if (health <= 0)
        {
            GetComponent<LootBag>().InstantiateLoot(transform.position);
            Destroy(gameObject);
            Debug.Log("Object was deleted");
        }
    }
    public void Sethealth(int bonusHealth)
    {
        health += bonusHealth;
        if (health <= 0)
        {
            health = maxHealth;
        }
    }
}
