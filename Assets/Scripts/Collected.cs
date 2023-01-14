using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    [SerializeField] Transform positionFinal;

    public bool isCollected;
    void Start()
    {
        // Find whith name
       // positionFinal = GameObject.Find("LeftUp").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionFinal.position, 50f * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollected = true;
        }
    }



}
