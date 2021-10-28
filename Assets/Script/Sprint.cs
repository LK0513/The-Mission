using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    public float totalStamina;
    public float stamina;
    
    public GameObject staminaBar;
    void Awake()
    {
        stamina = totalStamina;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            MoveR.isRunning = true;
            MoveL.isRunning = true;
            stamina -= 0.5f;
        }
        else
        {
            MoveR.isRunning = false;
            MoveL.isRunning = false;
        }

        if(stamina < totalStamina && !Input.GetKey(KeyCode.LeftShift))
        {
            stamina += 0.15f;
        }

        if(staminaBar != null)
        {
            //adjust size of the bar
            staminaBar.transform.localScale = new Vector2(stamina / totalStamina, staminaBar.transform.localScale.y);
        }
    }
}
 