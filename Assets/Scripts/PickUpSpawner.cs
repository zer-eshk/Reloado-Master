using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpSpawner : MonoBehaviour
{
    public GameObject ManaCapsule;
    public GameObject hpCapsule;
    public bool spawnMana;
    public bool spawnHp;
    public float manaCapsuleInterval = 10f;
    public float hpCapsuleInterval = 20f;
    public float Pointx_1 = 0;
    public float Pointx_2 = 0;
    public float Pointy_1 = 0;
    public float Pointy_2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(spawnHp==true) 
        StartCoroutine(SpawnHpCapsule());
        if(spawnMana==true)
        StartCoroutine(SpawnManaCapsule());
    }

    
    IEnumerator SpawnManaCapsule()
    {
        while (true) {
            yield return new WaitForSeconds(manaCapsuleInterval);
            Instantiate(ManaCapsule, new Vector3(Random.Range(Pointx_1, Pointx_2), Random.Range(Pointy_1, Pointy_2), 0f), Quaternion.identity);
        }

    }
    IEnumerator SpawnHpCapsule()
    {
        while (true) {
            yield return new WaitForSeconds(hpCapsuleInterval);
            Instantiate(hpCapsule, new Vector3(Random.Range(Pointx_1, Pointx_2), Random.Range(Pointy_1, Pointy_2), 0f), Quaternion.identity);
        }


    }

   
}
