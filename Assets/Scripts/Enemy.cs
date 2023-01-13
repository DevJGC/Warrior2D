using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    // Position X Player
    [SerializeField] GameObject playerPositionObject;

    // Diamond
    [SerializeField] GameObject diamondPrefab;


    [SerializeField] IsAttackingScript isAttackingScript;
    [SerializeField] Animator attackPlayer;

    [SerializeField] bool inAttack;

    [SerializeField] float energyEnemy=1f;
   // [SerializeField] Image imageEnergyEnemy;
    [SerializeField] Animator animatorEnemy;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip dieSound;

    [SerializeField] CircleCollider2D colliderEnemy;

    // particle object
    [SerializeField] GameObject particlesEnemyBlood;



    void Start()
    {
        // Reference Coin Prefab
       // coin = GameObject.Find("Coin");
       
    }

    // Update is called once per frame
    void Update()
    {
        inAttack=isAttackingScript.isAttacking;

    // Change Flip Enemy look to Enemy
    if (transform.position.x > playerPositionObject.transform.position.x && energyEnemy>0f)
    {
       // Flip left Sprite renderer
       gameObject.GetComponent<SpriteRenderer>().flipX = true;
    }
    else
    {
       gameObject.GetComponent<SpriteRenderer>().flipX = false;
    }



        
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
        //Instantiate(diamondPrefab,transform.position,Quaternion.identity);


        // Instantiate diamondPrefab
        GameObject diamond = Instantiate(diamondPrefab,transform.position,Quaternion.identity);

        diamond.transform.SetParent(GameObject.FindWithTag("BaseLayer").transform);
        

        
        PlaySoundDieEnemy();
        animatorEnemy.SetTrigger("Die");
        colliderEnemy.enabled=false;
        animatorEnemy.SetBool("isLive",false);

        // active particles

        particlesEnemyBlood.SetActive(true);

        // Instantiate diamondPrefab
        

        // remove from father
        //coin.SetActive(true);
        //coin.transform.parent=null;
        // set parent to Tag layer
        //coin.transform.SetParent(GameObject.FindWithTag("BaseLayer").transform);


        // Destroy Enemy
        Destroy(gameObject,2f);
        
    }

    private void PlaySoundHurtEnemy()
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.PlayOneShot(hurtSound);
        }
    }

    private void PlaySoundDieEnemy()
    {
       
            audioSource.PlayOneShot(dieSound);
        
    }

    
}
