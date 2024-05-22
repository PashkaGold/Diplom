using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damag : MonoBehaviour
{
    public int collisionDamage = 10;
    public string collisionTagTree;
    public string collisionTagStone;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTagTree || coll.gameObject.tag == collisionTagStone)
        {
            Health health = coll.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeHit(collisionDamage);
            }
        }
    }
}
