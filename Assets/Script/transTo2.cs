using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transTo2 : MonoBehaviour
{

    void OnEnable()
    {
       SceneManager.LoadScene("second", LoadSceneMode.Single);
    }
}
