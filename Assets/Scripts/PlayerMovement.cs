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
    float velocityY;
    // capsule collider
    [SerializeField] CapsuleCollider2D capsuleCollider2D;
    

    // Animations
    [SerializeField] Animator animator;

    bool isRight;

    bool isDie=false;

    // sounds
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip dieSound;









    
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
       // animator = GetComponent<Animator>();
       capsuleCollider2D = GetComponent<CapsuleCollider2D>();

            
    }

    
    void Update()
    {

        // check y velocity
        velocityY = rb.velocity.y;
        if (velocityY >0)
        {
            // deactivate capsule collider
            capsuleCollider2D.enabled=false;
        }
        else
        {       
            // activate capsule collider
            capsuleCollider2D.enabled=true;

        }



        if (isDie==false)
        {

            PlayerControl();  

        }

    
    
    }

    public void PlayerControl()
    {
        CheckRigidBody2dGround();

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

        // Attack
        if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
        {   
            Attack();
        }

       // Jump
        if (Input.GetMouseButton(1) && isGrounded || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded )
        {
            audioSource.PlayOneShot(jumpSound);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }

        if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }

        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

        // dead
        if (Input.GetKeyDown(KeyCode.X) && isDie==false)
        {
            Die();
            isDie=true;
        }

        // hurt
         if (Input.GetKeyDown(KeyCode.H))
         {
            Hurt();
         }

    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        isGrounded = true;
        animator.SetBool("isJumping", false);

    }

    public void Attack()
    {
        audioSource.PlayOneShot(attackSound);
        animator.SetTrigger("AttackTrigger");
    }

    // hurt
    public void Hurt()
    {
        audioSource.PlayOneShot(hurtSound);
        animator.SetTrigger("Hurt");
    }

    // dead
    public void Die()
    {
        audioSource.PlayOneShot(dieSound);
        animator.SetTrigger("Die");
        Invoke("isDead",1f);
       
    }

    public void isDead()
    {
        animator.SetBool("isDead", true);
    }

    public void CheckRigidBody2dGround()
    {
        bool isAwake;   
        isAwake = rb.IsAwake();

        if (isAwake==false)
        {   
            isAwake=true;
            rb.WakeUp();
            isGrounded=true;
        }
        
    }
    

}
