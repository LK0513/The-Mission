using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveR : MonoBehaviour 
{
    //move
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private LayerMask lm;
    public float moves = 5;
    public float jumpS = 10;
    
    //visuals
    public AudioSource footstep;
    private Animator playerAnimation;
    //flip
    private bool faceRight = true;

    //sprint
    public static bool isRunning;

    //respawn
    private Vector3 respawnPoint;
    //death bar
    public GameObject DeathDetector;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        bc = transform.GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        //move
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            //right
            transform.Translate(Vector2.right * Time.deltaTime * moves);
        }

        //sprint
        if (isRunning)
        {
            moves = 10;
        }
        else
        {
            moves = 5;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpS;
        }

        //Animation
        //move
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            playerAnimation.SetBool("stand", false);
        }
        else
        {
            //stand
            playerAnimation.SetBool("stand", true);
        }

        //jump
        if (Input.GetKey(KeyCode.Space))
        {
            
            playerAnimation.SetBool("onGround", false);
        }
        else
        {
            //stand
            playerAnimation.SetBool("onGround", true);
        }

        //flip
        if (Input.GetKey(KeyCode.D) && !faceRight)
        {
            Flip();
        }
        else if (Input.GetKey(KeyCode.A) && faceRight)
        {
            Flip();
        }


        //move death bar with player
        DeathDetector.transform.position = new Vector2(transform.position.x, DeathDetector.transform.position.y);
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
        /*
        Vector2 characterScale = transform.localScale;
        characterScale.x *= -1;

        transform.localScale = characterScale;
        */
    }


    //jump
    private bool IsGrounded()
    {
        RaycastHit2D rc = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, lm);
        //if not null, hit the ground
        return rc.collider != null; 
    }


    //respawn
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Death")
        {
            //respawn player to the save point
            transform.position = respawnPoint;
            
        }
        else if(collision.tag == "Respawn")
        {
            respawnPoint = transform.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = respawnPoint;
        }
    }
}
