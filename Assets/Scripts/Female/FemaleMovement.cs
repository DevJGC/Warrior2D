using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FemaleMovement : MonoBehaviour
{
    // Reference player
    [SerializeField] Transform player;
    // reference player dialog system
    [SerializeField] GameObject dialogPlayer;

    bool femaleDistanceBool;
    [SerializeField] SpriteRenderer spriteRenderer;

    // referencie female animator
    [SerializeField] Animator femaleAnimator;

    float xFemale;

    // Dialog panel
    [SerializeField] GameObject dialogPanel;
    // UI TMPro text
    [SerializeField] TMP_Text dialogText;
    [SerializeField] Button buttonContinue;

    // Counter flow dialog 
    public int dialogCounter;

    // sound
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClipType;

    void Start()
    {
        Invoke("ActiveDialogPanel",1);
        // invoke text program sequence
        StartCoroutine("DialogText","Cariño, la chiquilla no está en casa, ha dejado una nota...");   
        // startcoroutine wait seconds
        StartCoroutine("WaitSeconds",2);
        

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
            // cuando toca al player
        }
    }

    // Active dialog panel
    public void ActiveDialogPanel()
    {
        dialogPanel.SetActive(true);
        dialogText.text = "";

    }

    // Close dialog panel
    public void CloseDialogPanel()
    {
        dialogPanel.SetActive(false);
       
    }

    // ienumerator Show Text
    IEnumerator DialogText(string textDialog)
    {
        buttonContinue.GetComponent<Button>().interactable = false;

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < textDialog.Length; i++)
        {
            dialogText.text += textDialog[i];
            audioSource.PlayOneShot(audioClipType);
            yield return new WaitForSeconds(0.05f);
            // activate button continue
            buttonContinue.GetComponent<Button>().interactable = false;
            
        }
        buttonContinue.GetComponent<Button>().interactable = true;
        
    }

    // ienumerator wait seconds
    IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        
    }

    // function count dialog press button canvas

    public void CountDialog()
    {
        dialogCounter++;
        dialogText.text = "";
        if (dialogCounter == 1)
        {
            StartCoroutine("DialogText","Dice que se quiere casar con el Jonathan, el hijo de la Paqui...");
            StartCoroutine("WaitSeconds", 0.5f);
        }
        if (dialogCounter == 2)
        {
            StartCoroutine("DialogText","Esa familia son todos unos perros. No dan palo al agua!!!...");
            StartCoroutine("WaitSeconds", 0.5f);
        }
        if (dialogCounter == 3)
        {
            StartCoroutine("DialogText","Así que ve a por ella antes de que me la preñen. VE!!!");
            StartCoroutine("WaitSeconds", 0.5f);
        }
        if (dialogCounter == 4)
        {
            CloseDialogPanel();
            // activate dialogPlayer object
            dialogPlayer.SetActive(true);
        }

        if (dialogCounter == 6)
        {
            ActiveDialogPanel();
            StartCoroutine("DialogText","Ufff... cómo me pones Manolo cuando eres así de bruto...");
            StartCoroutine("WaitSeconds", 0.5f);
        }

        if (dialogCounter == 7)
        {
            CloseDialogPanel();
            // activate dialogPlayer object
           // dialogPlayer.SetActive(true);
        }

        
    }


    
}
