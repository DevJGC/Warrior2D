using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip eatSound;

    [SerializeField] AudioClip coinSound;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            audioSource.PlayOneShot(eatSound);
            player.AddEnergy();
            Destroy(collision.gameObject,1f);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            //audioSource.PlayOneShot(eatSound);
            //player.AddEnergy();
            //Destroy(collision.gameObject);
            player.Hurt();

        }

        if (collision.gameObject.tag == "Dead")
        {
            //audioSource.PlayOneShot(eatSound);
            //player.AddEnergy();
            //Destroy(collision.gameObject);
            player.isDie=true;
            player.energy=0f;
            player.Die();

        }

        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound);

            player.AddCoin();
            Destroy(collision.gameObject,1f);


        }





    }


    


}
