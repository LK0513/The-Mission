using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkSpeed;
    public bool canPatrol;

    public Rigidbody2D rb;
    void Start()
    {
        canPatrol = true;
    }

    void Update()
    {
        if(canPatrol)
        {
            Patrol();
        }
    }

    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        canPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        canPatrol = true;
    }    
}
