using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkSpeed;
    public bool canPatrol;
    //public bool turn;

    public Rigidbody2D rb;
    //public BoxCollider2D bc;

    [SerializeField] private LayerMask lm;
    void Start()
    {
        canPatrol = true;
       
    }

    void Update()
    {
        if (canPatrol)
        {
            Patrol();
        }
        if (ShouldTurn())
        {
            Flip();
        }

    }

    void Patrol()
    {
        transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);
    }

    void Flip()
    {
        canPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        canPatrol = true;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.blue);
        Debug.DrawRay(transform.position, Vector2.left, Color.red);
    }

    bool ShouldTurn()
    {
        bool turn;
        RaycastHit2D rcV = Physics2D.Raycast(transform.position, Vector2.down, 1f, lm);
        RaycastHit2D rcHL = Physics2D.Raycast(transform.position, Vector2.left, 1f, lm);
        RaycastHit2D rcHR = Physics2D.Raycast(transform.position, Vector2.right, 1f, lm);

        if (rcV.collider == null || rcHL.collider != null || rcHR.collider != null)
        {
            turn = true;
        }
        else
        {
            turn = false;
        }

        return turn;
    }
}
