using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    GameObject player;
    GameObject centerUp;
    public bool isCollectedDiamond;

    AudioSource audioSource;
    [SerializeField] AudioClip diamondSound;

    void Start()
    {
        player = GameObject.Find("Player");
        centerUp = GameObject.Find("CenterUp");
        audioSource = GetComponent<AudioSource>();
        
    }

   
    void Update()
    {
        if (isCollectedDiamond)
        {
            transform.position = Vector3.MoveTowards(transform.position, centerUp.transform.position, 50f * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            audioSource.PlayOneShot(diamondSound);
            isCollectedDiamond = true;
            player.GetComponent<PlayerMovement>().AddDiamond();
            Destroy(gameObject,1);
        }
    }
}
