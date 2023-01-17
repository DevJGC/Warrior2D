using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTutorialScript : MonoBehaviour
{
    // Reference player
    [SerializeField] GameObject player;

    // reference player dialog system
    [SerializeField] DialogPlayer dialogPlayer;

    // reference audiosource

    bool showFirst;
    int count;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function detection trigger collider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && showFirst==false && count==0)
        {
            // call function dialog player
            dialogPlayer.GetComponent<DialogPlayer>().ActiveDialogPanel();
            dialogPlayer.GetComponent<DialogPlayer>().dialogCounterPlayer = 5;
            // activate CountDialog()
            dialogPlayer.GetComponent<DialogPlayer>().CountDialogPlayer();
            // set bool to true
            showFirst = true;
            count=1;
        }    
    }




}
