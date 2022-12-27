using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] bool isGrounded;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] float speed = 5f;
    float horizontalMovement;

    [SerializeField] Rigidbody2D rb;


    
    void Start()
    {

            
    }

    
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * speed;

       


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

    
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
        //Debug.Log("Suelo");
    }





}
