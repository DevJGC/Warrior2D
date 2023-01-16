using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleMovement : MonoBehaviour
{
    // Reference player
    [SerializeField] Transform player;
    bool femaleDistanceBool;
    [SerializeField] SpriteRenderer spriteRenderer;

    // referencie female animator
    [SerializeField] Animator femaleAnimator;

    float xFemale;

    void Start()
    {
        
    }

    void Update()
    {
        PlayerDistance();
    }

    // player distance
    private void PlayerDistance()
    {
        if (!femaleDistanceBool)
        {
        // move in X keep distance whith movetowards
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), 1 * Time.deltaTime);
        }

        // stop in X distance to player
        if (Vector3.Distance(transform.position, player.position) <2)
        {
            femaleDistanceBool=true;
            // active Walk animator
            femaleAnimator.SetInteger("Walk",1);
            Debug.Log("cerca");
        } else 
        {
            femaleDistanceBool=false;
            femaleAnimator.SetInteger("Walk",0);
        }

        // flip sprite  
        xFemale = player.position.x - transform.position.x;
        if (xFemale > 0)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
            



    }


    // When player enters trigger
    private void OnTriggerEnter(Collider other)
    {
        // If player enters trigger
        if (other.gameObject == player)
        {
        }
    }

}
