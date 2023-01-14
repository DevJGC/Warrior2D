using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public int coin;
    public int diamond;

    // sounds
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip dieSound;
    [SerializeField] AudioClip lifeSound;

    // Referencias a canvas
    public float energy=1f;
    
    [SerializeField] Image imageEnergy;
    [SerializeField] TMP_Text textCoin;
    [SerializeField] TMP_Text textDiamond;

    // CheckPoint Position
    [SerializeField] Transform checkPointPosition;
    public bool isCheckPointBool=false;

    // Active particles Blood
    [SerializeField] GameObject particlesBlood;
    








    
    void Start()
    {
       // rb = GetComponent<Rigidbody2D>();
       // animator = GetComponent<Animator>();
       capsuleCollider2D = GetComponent<CapsuleCollider2D>();

       //energy=1f;

            
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
        if (Input.GetKeyDown(KeyCode.Space))
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
        imageEnergy.color = Color.red;
        audioSource.PlayOneShot(dieSound);
        animator.SetTrigger("Die");
        Invoke("isDead",1f);
                    // active parcicle object
                    particlesBlood.SetActive(true);
       
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
            imageEnergy.color = Color.red;
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

    public void AddCoin()
    {
        coin++;
        textCoin.text = coin.ToString();

    }

    public void CheckPoint()
    {
        //energy=0f;
        //SyncEnergy();

       // imageEnergy.fillAmount = 0f;
        
        transform.position = checkPointPosition.position;
        isDie=false;
        

        
        animator.SetBool("isDead", false);
        animator.SetFloat("Speed", 0f);
        audioSource.PlayOneShot(lifeSound);
        Invoke ("ResetEnergy",1f);


    }

    private void ResetEnergy()
    {
        energy=1f;
        imageEnergy.color = Color.white;
        imageEnergy.fillAmount = 1f;
                    // desactive parcicle object
                    particlesBlood.SetActive(false);
        

        

        //SyncEnergy();
    }

    public void AddDiamond()
    {
        diamond++;
        textDiamond.text = diamond.ToString();
    }    



    

}
