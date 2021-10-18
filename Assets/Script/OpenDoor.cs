using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    int counter;
    private Animator door;
    public static bool card = false;

    private void Start()
    {
        door = GetComponent<Animator>();
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        counter++;
        if (collision.gameObject.CompareTag("Player") && card && counter == 1)
        {
            door.SetBool("havecard", true);
        }
    }
}
