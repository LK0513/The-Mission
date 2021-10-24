using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkSpeed;
    public bool canPatrol;

    public Rigidbody2D rb;
    public BoxCollider2D bc;
    [SerializeField] private LayerMask lm;
    void Start()
    {
        canPatrol = true;
        
    }

    void Update()
    {
        RaycastHit2D rc = Physics2D.BoxCast(bc.bounds.min, bc.bounds.size, 0f, Vector2.down, 0.3f, lm);
        if (canPatrol)
        {
            Patrol();
        }
        if(rc.collider == null)
        {
            Flip();
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
