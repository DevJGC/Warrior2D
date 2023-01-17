using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorialExit : MonoBehaviour
{
    bool showFirst;
    int count;
    // audio source
    [SerializeField] AudioSource audioSource;
    // audio clip
    [SerializeField] AudioClip musicEpic;

    // player
    [SerializeField] GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function exit trigger collider   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && showFirst==false && count==0)
        {
            // set bool to false
            showFirst = true;
            count=1;
            // play loop music
            audioSource.Play();
        }
    }
}
