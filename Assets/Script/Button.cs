using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    int counter = 0;
    public GameObject ceiling;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        counter++;
        if (collision.gameObject.CompareTag("Player") && counter == 1)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.15f);
        }
        if(ceiling != null)
        {
            Destroy(ceiling);
        }
    }
    void Update()
    {
        
    }
}
