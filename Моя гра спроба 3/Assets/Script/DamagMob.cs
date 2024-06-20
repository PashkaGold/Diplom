using UnityEngine;

public class DamagMob : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTag;
    public float damageInterval = 1f; // Інтервал між нанесенням урону в секундах

    private float damageTimer = 0f; // Залишаємо приватним

    private void Update()
    {
        damageTimer += Time.deltaTime;
    }

    public float GetDamageTimer()
    {
        return damageTimer;
    }

    public void ResetDamageTimer()
    {
        damageTimer = 0f;
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(collisionTag))
        {
            if (damageTimer >= damageInterval)
            {
                // Спроба отримати компонент PlayerHealth
                PlayerHealth playerHealth = coll.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    // Нанесення урону
                    playerHealth.TakeDamage(collisionDamage);
                    ResetDamageTimer(); // Скидання таймера після нанесення урону
                }
                else
                {
                    Debug.LogWarning("Об'єкт з тегом " + collisionTag + " не має компонента PlayerHealth.");
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag(collisionTag))
        {
            // Скидання таймера при роз'єднанні колізії
            ResetDamageTimer();
        }
    }
}
