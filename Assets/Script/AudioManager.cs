using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource sound;
    
    public static AudioClip jumpS, CdeathS;
    public static AudioClip buttonS, crashS, cardS, unlockS;
    public static AudioClip shootS, paperS, keyS, gateS, MdeathS;

    private void Start()
    {
        jumpS = Resources.Load<AudioClip>("jump");
        CdeathS = Resources.Load<AudioClip>("Cdeath");

        buttonS = Resources.Load<AudioClip>("button");
        crashS = Resources.Load<AudioClip>("crash");
        cardS = Resources.Load<AudioClip>("card");
        unlockS = Resources.Load<AudioClip>("unlock");

        shootS = Resources.Load<AudioClip>("shoot");
        paperS = Resources.Load<AudioClip>("paper");
        keyS = Resources.Load<AudioClip>("key");
        gateS = Resources.Load<AudioClip>("gate");
        MdeathS = Resources.Load<AudioClip>("Mdeath");

        sound = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip)
    {
        switch(clip)
        {

            case "jump":
                sound.PlayOneShot(jumpS);
                break;
            case "Cdeath":
                sound.PlayOneShot(CdeathS);
                break;

            //first scene
            case "button":
                sound.PlayOneShot(buttonS);
                break;
            case "crash":
                sound.PlayOneShot(crashS);
                break;
            case "card":
                sound.PlayOneShot(cardS);
                break;
            case "unlock":
                sound.PlayOneShot(unlockS);
                break;

            //second scene
            case "shoot":
                sound.PlayOneShot(shootS, 0.7f);
                break;
            case "paper":
                sound.PlayOneShot(paperS);
                break;
            case "key":
                sound.PlayOneShot(keyS);
                break; 
            case "gate":
                sound.PlayOneShot(gateS, 0.7f);
                break;
            case "Mdeath":
                sound.PlayOneShot(MdeathS);
                break; 
        }
    }
}


/*
void Update()
{
    played = false;
    if (OpenDoor.card && !played)
    {
        sound.PlayOneShot(pickup);
        played = true;
    }

    if(Button.stepped && !played)
    {
        sound.PlayOneShot(crash);
        played = true;
    }

    //played = true;
}*/
