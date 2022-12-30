using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] IsAttackingScript isAttackingScript;
    [SerializeField] Animator attackPlayer;

    [SerializeField] bool inAttack;

    [SerializeField] float energyEnemy=1f;
   // [SerializeField] Image imageEnergyEnemy;
    [SerializeField] Animator animatorEnemy;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hurtSound;

    [SerializeField] CircleCollider2D colliderEnemy;



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        inAttack=isAttackingScript.isAttacking;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!inAttack)
            {
                //player.Hurt();
            }
            else
            {
                //player.AddEnergy();
                energyEnemy-=0.1f;
                HurtEnemy();

  
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (inAttack)
            {
                HurtEnemy();
                
            }
            
        }
    }

    private void HurtEnemy()
    {
        energyEnemy-=0.01f;
        PlaySoundHurtEnemy();
        animatorEnemy.SetTrigger("Hurt");

                if (energyEnemy<=0)
                {
                    EnemyDie();
                }

    }

    private void EnemyDie()
    {
        PlaySoundHurtEnemy();
        animatorEnemy.SetTrigger("Die");
        colliderEnemy.enabled=false;
        animatorEnemy.SetBool("isLive",false);
        Destroy(gameObject,2f);
        
    }

    private void PlaySoundHurtEnemy()
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.PlayOneShot(hurtSound);
        }
    }

    
}
