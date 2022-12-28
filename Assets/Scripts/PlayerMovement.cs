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

    // Animations
    [SerializeField] Animator animator;

    bool isRight;





    
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
       // animator = GetComponent<Animator>();

            
    }

    
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));

        if (horizontalMovement > 0 && isRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = false;
        }
        else if (horizontalMovement < 0 && !isRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isRight = true;
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("Attack", true);   
        }
        else
        {
            animator.SetBool("Attack", false);
        }


       
        if (Input.GetMouseButton(1) && isGrounded)
       // if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Activar para tecla Espacio
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }


 
    

    
    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);

        //Debug.Log("Suelo");
    }





}
