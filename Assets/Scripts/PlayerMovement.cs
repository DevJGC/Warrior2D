using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public bool isDie=false;

    // sounds
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip dieSound;

    // Referencias a canvas
    public float energy=1f;
    
    [SerializeField] Image imageEnergy;








    
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            audioSource.PlayOneShot(jumpSound);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            
        }

        if (isGrounded == false)
        {
            animator.SetBool("isJumping", true);
        }

        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
        if (rb.velocity.y == 0) isGrounded=true;

        //{
        //    animator.SetBool("isJumping", true);
        //}


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
       if (other.gameObject.CompareTag("Ground"))
       {
            isGrounded = true;
            //animator.SetBool("isJumping", false);
       }
       else
        {
            isGrounded = false;
            animator.SetBool("isJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if (other.gameObject.CompareTag("Ground"))
       {
            isGrounded = true;
            animator.SetBool("isJumping", false);
       }
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
        energy -= 0.1f;
        SyncEnergy();
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

        if (isGrounded==true) animator.SetBool("isJumping", false);        
    }

    public void SyncEnergy()
    {
        imageEnergy.fillAmount = energy;

        if(energy <=0)
        {
            isDie=true;
            Die();
        }
    }

    public void AddEnergy()
    {
        if(energy < 1f)
        {
            energy += 0.1f;
        }
       
        SyncEnergy();
    }

    

}
