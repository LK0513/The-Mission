using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();

            AudioManager.PlaySound("shoot");
        }


    }

    void Shoot()
    {
        //add bullet into the scene
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
