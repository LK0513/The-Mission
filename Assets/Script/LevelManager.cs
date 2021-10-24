using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    /*
    public enum Scene
    {
        intro,
        Mission,
        Meet,
        Second,
    }
    */

    private int nextScene;
    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log(nextScene);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
