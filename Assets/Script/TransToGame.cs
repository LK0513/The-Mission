using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransToGame : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Mission", LoadSceneMode.Single);
    }
}
