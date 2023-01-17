using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class DialogPlayer : MonoBehaviour
{
    // reference player
    public GameObject player;

    
    [SerializeField] GameObject dialogPanel;
    // UI TMPro text
    [SerializeField] TMP_Text dialogText;

    // Counter flow dialog 
    public int dialogCounterPlayer;
    [SerializeField] Button buttonContinuePlayer;

    // reference female
    [SerializeField] GameObject femalePlayer;

    // sound
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClipType;
    

    void Start()
    {
        Invoke("ActiveDialogPanel",1);
        // invoke text program sequence
        StartCoroutine("DialogText","Vale!!, no te preocupes, ahora salgo a rescatarla...");   
        // startcoroutine wait seconds
        StartCoroutine("WaitSeconds",3);
    }

    // Update is called once per frame
    void Update()
    {
        // if player is not null
        if (player != null)
        {
            // set position of dialog box to player position position 20 X to left
            transform.position = new Vector3(player.transform.position.x +1, player.transform.position.y, player.transform.position.z);
           // transform.position = player.transform.position;

        }
        
    }

    // Active dialog panel
    public void ActiveDialogPanel()
    {
        dialogPanel.SetActive(true);
        dialogText.text = "";

    }

    // Close dialog panel
    private void CloseDialogPanel()
    {
        dialogPanel.SetActive(false);
       
    }

    // ienumerator Show Text
    IEnumerator DialogText(string textDialog)
    {
        buttonContinuePlayer.GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < textDialog.Length; i++)
        {
            dialogText.text += textDialog[i];
            audioSource.PlayOneShot(audioClipType);
            yield return new WaitForSeconds(0.05f);
            buttonContinuePlayer.GetComponent<Button>().interactable = false;
        }
    
         buttonContinuePlayer.GetComponent<Button>().interactable = true;

    }

    // ienumerator wait seconds
    IEnumerator WaitSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        //CloseDialogPanel();
        
    }

    // function count dialog press button canvas

    public void CountDialogPlayer()
    {
        dialogCounterPlayer++;
        dialogText.text = "";
        if (dialogCounterPlayer == 1)
        {
            StartCoroutine("DialogText","Como se haya liado con el niñato ese, la espabilo!!!...");
            StartCoroutine("WaitSeconds", 0.5f);
        }
        if (dialogCounterPlayer == 2)
        {
            StartCoroutine("DialogText","Tú quédate aquí, no se lo que tardaré. Llevo el hacha...");
            StartCoroutine("WaitSeconds", 0.5f);
        }
        if (dialogCounterPlayer == 3)
        {
            StartCoroutine("DialogText","El que se meta en mi camino lo despellejo como a un conejo.");
            StartCoroutine("WaitSeconds", 0.5f);
        }
        if (dialogCounterPlayer == 4)
        {
            CloseDialogPanel();
            // active ActiveDialogPanel() female object
            femalePlayer.GetComponent<FemaleMovement>().ActiveDialogPanel();
            femalePlayer.GetComponent<FemaleMovement>().dialogCounter = 5;
            // activate CountDialog()
            femalePlayer.GetComponent<FemaleMovement>().CountDialog();
           
        }

        if (dialogCounterPlayer == 6)
        {
            ActiveDialogPanel();
            
            StartCoroutine("DialogText","Oye, Tu!!, el que está detrás de la pantalla!, si tu!!!");
            StartCoroutine("WaitSeconds", 0.5f);   
        }

        if (dialogCounterPlayer == 7)
        {
            StartCoroutine("DialogText","Aýudame!, solo tienes que moverme con los cursores < >");
            StartCoroutine("WaitSeconds", 0.5f);
        }   

        if (dialogCounterPlayer == 8)
        {
            StartCoroutine("DialogText","Y para saltar con la flecha hacia arriba... ");
            StartCoroutine("WaitSeconds", 0.5f);
        }  

        if (dialogCounterPlayer == 9)
        {
            StartCoroutine("DialogText","Y si pulsas 2 veces rápido, haré doble salto... ");
            StartCoroutine("WaitSeconds", 0.5f);
        }

        if (dialogCounterPlayer == 10)
        {
            StartCoroutine("DialogText","Y para pegar hachazos, pulsa la tecla Espacio... ");
            StartCoroutine("WaitSeconds", 0.5f);
        }    

        if (dialogCounterPlayer == 11)
        {
            StartCoroutine("DialogText","Ahh! y ese cartelito con la estrella verde, es para...");
            StartCoroutine("WaitSeconds", 0.5f);
        }  

        if (dialogCounterPlayer == 12)
        {
            StartCoroutine("DialogText","guardar el punto de avance, es decir, un Checkpoint, imbécil...");
            StartCoroutine("WaitSeconds", 0.5f);
        }  

        if (dialogCounterPlayer == 13)
        {
            StartCoroutine("DialogText","que te lo tengo que decir todo, así que cúrraterlo....");
            StartCoroutine("WaitSeconds", 0.5f);
        }

        if (dialogCounterPlayer == 14)
        {
            CloseDialogPanel();

        }     


    }
}
