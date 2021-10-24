using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour 
{
    //move
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] private LayerMask lm;
    public float moves = 5;
    public float jumpS = 10;

    int counter = 0;

    //visuals
    public Sprite mersenary;
    public AudioSource footstep;
    private Animator playerAnimation;

    //sprint
    public static bool isRunning;

    //respawn
    private Vector3 respawnPoint;
    public GameObject Death;
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
        
        //GetComponent<SpriteRenderer>().sprite = mersenary;
        Vector3 characterScale = transform.localScale;
        
        //move
        if (Input.GetKey(KeyCode.A))
        {
            //counter++;
            transform.Translate(Vector2.left * Time.deltaTime * moves);
            characterScale.x = 1;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * moves);
            characterScale.x = -1;
        }

        //sprint
        if(isRunning)
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
        else if (Input.GetKey(KeyCode.Space))
        {
            //jump
            playerAnimation.SetBool("onGround", false);
        }
        else
        {
            //stand
            playerAnimation.SetBool("stand", true);
            playerAnimation.SetBool("onGround", true);
        }

        //counter = 0;
        transform.localScale = characterScale;


    }
    private bool IsGrounded()
    {
        RaycastHit2D rc = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, lm);
        //if not null, hit the ground
        return rc.collider != null; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Death")
        {
            //respawn player to the start
            transform.position = respawnPoint;
            
        }
        else if(collision.tag == "Respawn")
        {
            respawnPoint = transform.position;
        }
    }
}
