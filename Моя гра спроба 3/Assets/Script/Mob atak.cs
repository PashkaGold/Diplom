using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mobatak : MonoBehaviour
{
    public float speed;

    public int positiobofPatrol;

    public Transform point;

    bool moveingRinght;

    Transform player;

    public float stoppingDistance;

    bool chill = false;

    bool angry = false;

    bool goBack = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positiobofPatrol && angry==false)
        {
            chill = true;
        }
        
        if(Vector2.Distance(transform.position, player.position) < stoppingDistance) 
        {
            angry = true;
            chill = false;
            goBack = false ;
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }

        if (chill == true)
        {
            Chill();
        }
        else if (angry == true) 
        {
            Angre();
        }
        else if (goBack == false) 
        {
            GoBack();
        } 
    }
    void Chill()
    {
        if (transform.position.x > point.position.x + positiobofPatrol)
        {
            moveingRinght = false; 
        }
        else if (transform.position.x < point.position.x - positiobofPatrol)
        {
            moveingRinght = true;
        }
        if (moveingRinght)
        {
            transform.position = new Vector2(transform.position.x + speed*Time.deltaTime ,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

    }
    void Angre()
    {
        transform.position = Vector2.MoveTowards(transform.position,player.position, speed * Time.deltaTime);
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
