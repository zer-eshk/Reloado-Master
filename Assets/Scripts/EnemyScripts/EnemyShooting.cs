using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;
    public float bulletCd = 5;
    // Start is called before the first frame update
    void Start()
    {
        ShotingBullet();
        StartCoroutine(BulletSpawner());
    }

    private void ShotingBullet()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
    }

   
    IEnumerator BulletSpawner()
    {
        while (true) {

            yield return new WaitForSeconds(bulletCd);
            ShotingBullet();

        }
        
    }

}
