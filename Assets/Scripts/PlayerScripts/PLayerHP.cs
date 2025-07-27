using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class PLayerHP : MonoBehaviour
{
    public int maxHP = 100;
    public int curentHp;
    public float invincibilityTime = 1.5f;
    public float invincibilitytimer  = 0;
    private SpriteRenderer SpriteRenderer;
    private Color orginalColor;


    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        orginalColor=SpriteRenderer.color;
        curentHp = maxHP;
    }
    private void Update()
    {
        
        if (invincibilitytimer > 0)
        {
            SpriteRenderer.color =Color.red;
            invincibilitytimer -= Time.deltaTime;
        }
        if(invincibilitytimer<=0)
        { SpriteRenderer.color =orginalColor;}
    }
    private void OnCollisionStay2D(Collision2D other)
    
 
    {
        if (other.gameObject.CompareTag("Enemy")&&invincibilitytimer<=0)

        {
            if (other != null)
            {
                
                invincibilitytimer=invincibilityTime;
                
                EnemyHp enemy = other.gameObject.GetComponent<EnemyHp>();
                TakeDamage(enemy.damageToPlayer);
            }
        }
       
      
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullet") && invincibilitytimer <= 0)

        {
            if (other != null)
            {

                invincibilitytimer = invincibilityTime;

                EnemyBullet enemyBullet = other.gameObject.GetComponent<EnemyBullet>();
                TakeDamage(enemyBullet.bulletDamage);
                Destroy(other.gameObject);
            }
        }
    }
    private void TakeDamage(int damage)
    {
        
        curentHp -=damage;
        if (curentHp <= 0)
        {

            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }

    }
}
