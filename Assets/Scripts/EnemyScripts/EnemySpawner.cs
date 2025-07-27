using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnIndicator;
    public GameObject enemy_1;
    public float spawnerDelay = 0;
    public float enemyInterval = 1f;
    public float warningTime;
    public float Pointx_1 = 0;
    public float Pointx_2 = 0;
    public float Pointy_1 = 0;
    public float Pointy_2 = 0;
    
    Vector3 spawnPos;

    private void Start()
    {
        StartCoroutine(Enemy_1Spawner());
    }
    IEnumerator Enemy_1Spawner()
    {
        yield return new WaitForSeconds(spawnerDelay);
        while (true)

        {
            
            spawnPos = new Vector3(Random.Range(Pointx_1, Pointx_2), Random.Range(Pointy_1, Pointy_2), 0f);
            GameObject Indicator = Instantiate(spawnIndicator, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(warningTime);
            Instantiate(enemy_1, spawnPos, Quaternion.identity);
            Destroy(Indicator);
            yield return new WaitForSeconds(enemyInterval);



        }

    }


}
