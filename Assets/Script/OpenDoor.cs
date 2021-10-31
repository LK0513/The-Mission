using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    int counter;
    private Animator door;
    public static bool card = false;

    [SerializeField] private Image key;

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
    private void Update()
    {
        if (card)
        {
            key.enabled = true;
        }
        if(!card)
        {
            key.enabled = false;
        }
    }

}
