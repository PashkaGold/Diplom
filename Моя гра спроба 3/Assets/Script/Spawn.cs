using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject obj;
    private float randomX;
    Vector2 whereToSpawn;
    public float spavnDelay;
    float nextSpawn = 0.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Time.time > nextSpawn) 
        {
            nextSpawn = Time.time + spavnDelay;
            randomX = Random.Range(-8, 8);
            whereToSpawn = new Vector2 (randomX, transform.position.y);
            GameObject Enemi = Instantiate (obj, whereToSpawn,Quaternion.identity);
            
        }
    }
}
