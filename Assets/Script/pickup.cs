using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                AudioManager.PlaySound("card");
            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                AudioManager.PlaySound("key");
            }
            OpenDoor.card = true;
            Destroy(gameObject);
        }
    }
}
