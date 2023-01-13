using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool isCheckPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheckPoint)
        {
           // transform.position = Vector3.MoveTowards(transform.position, positionFinal.position, 50f * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCheckPoint = true;
        }
    }
}
