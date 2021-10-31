using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingS;
    int counter = 0;
    

    private void Start()
    {
        textDisplay.text = "";
        
    }
    private void OnEnable()
    {
        StartCoroutine(Type());
    }
    private void Update()
    {
        //Vector2 right = new Vector2(736, transform.position.y);
        //Vector2 left = new Vector2(420, transform.position.y);
        //float x = transform.position.x;
        counter++;
        if (counter == 200)
        {
            /*
            if(x == 420)
            {
                textDisplay.transform.position = right;
            }
            else if (x == 736)
            {

                textDisplay.transform.position = left;
            }*/
            Next();
            counter = 0;
        }
    }
    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingS);
        }
    }

    private void Next()
    {
        if(index<sentences.Length -1)
        {
            //auto play
            index++;
            //reset line
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }
}
