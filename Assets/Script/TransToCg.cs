using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransToCg : MonoBehaviour
{
    private int nextScene;
    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(nextScene);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
