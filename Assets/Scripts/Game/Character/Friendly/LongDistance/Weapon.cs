using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot ()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if (bullet != null){
            bullet.transform.position = firePoint.position;
            bullet.SetActive(true);
        }
    }

}
