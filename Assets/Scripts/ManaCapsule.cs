using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCapsule : MonoBehaviour
{
    public int manaGain = 100;
    public float lifeTime = 20;

    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            Shoting shoting=other.GetComponent<Shoting>();
            if (shoting != null )
            {
                
                shoting.curentMana += manaGain;
                if(shoting.curentMana > shoting.maxMana)
                {
                    shoting.curentMana=shoting.maxMana;
                }
                Destroy(gameObject);
            }
            
        }
    }
}
