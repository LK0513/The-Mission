using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
   
    void Update()
    {
        //translate mouse position on screen to postion in game
        Vector2 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(gunpos.x>transform.position.x)
        {
            transform.eulerAngles = new Vector2(transform.rotation.x, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(transform.rotation.x, 180);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }


    }

    void Shoot()
    {
        //translate position on screen to postion in game
        //Vector2 mouseposition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        //Vector2 firepointD = new Vector2 (firePoint.position.x, firePoint.position.y);
        

        //add bullet into the scene
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
