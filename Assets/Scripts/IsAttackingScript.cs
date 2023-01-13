using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsAttackingScript : MonoBehaviour
{
    public bool isAttacking;
    [SerializeField] PlayerMovement player;



    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }


    public void isAttackingBool()
    {
        isAttacking=true;
    }

    public void isNotAttackingBool()
    {
        isAttacking=false;
    }

    public void CallCheckPoint()
    {
        player.CheckPoint();
    }
}
