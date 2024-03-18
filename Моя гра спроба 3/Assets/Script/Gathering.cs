using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
      if (coll.gameObject.tag == "Tree Gathering")
        {
            Destroy(coll.gameObject);
        }
      else if (coll.gameObject.tag == "Stone Gathering")
        {
            Destroy(coll.gameObject);
        }
    }
}
