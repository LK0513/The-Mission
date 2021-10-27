using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    //move
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    float horizontalMove = 0;
    public float moves = 5f;

    [SerializeField] private LayerMask lm;
    public float jumpS = 10;


    //visuals
    public Sprite mersenary;
    public AudioSource footstep;
    private Animator playerAnimation;

    bool faceRight = true;

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
        GetComponent<SpriteRenderer>().sprite = mersenary;
        playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if(horizontalMove > 0 && !faceRight)
        {
            Flip();
        }
        else if(horizontalMove < 0 && faceRight)
        {
            Flip();
        }

        //Animation
        if (horizontalMove != 0)
        {
            playerAnimation.SetBool("stand", false);
        }
        else if (horizontalMove == 0)
        {
            //stand
            playerAnimation.SetBool("stand", true);
            playerAnimation.SetBool("onGround", true);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //jump
            playerAnimation.SetBool("onGround", false);
        }
        

    }

    private void FixedUpdate()
    {

        //move player
        if (horizontalMove > 0.1f || horizontalMove < -0.1f)
        {
            rb.AddForce(new Vector2(horizontalMove * moves, 0f), ForceMode2D.Impulse);
           //transform.Rotate(0, characterScale.x * 180, 0);
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = Vector2.up * jumpS;
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D rc = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, lm);
        //if not null, hit the ground
        return rc.collider != null;
    }

    void Flip()
    {
        faceRight = !faceRight;

        /*
        Vector2 characterScale = transform.localScale;
        characterScale.x *= -1;

        transform.localScale = characterScale;
        */
        transform.Rotate(0, 180, 0);
    }
}

    /*
        //sprint
        if (isRunning)
        {
            moves = 10;
        }
        else
        {
            moves = 5;
        }

//move death bar with player
        DeathDetector.transform.position = new Vector2(transform.position.x, DeathDetector.transform.position.y);

    */



/*
private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Death")
    {
        //respawn player to the save point
        transform.position = respawnPoint;

    }
    else if (collision.tag == "Respawn")
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
*/
//}
