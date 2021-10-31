using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        if (collision.gameObject.CompareTag("Player") && card)
        {
            door.SetBool("havecard", true);
            card = false;

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                AudioManager.PlaySound("unlock");
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                AudioManager.PlaySound("gate");
            }
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
