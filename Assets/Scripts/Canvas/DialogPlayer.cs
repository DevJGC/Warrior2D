using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPlayer : MonoBehaviour
{
    // reference player
    public GameObject player;

    
    [SerializeField] GameObject dialogPanel;
    // UI TMPro text
    [SerializeField] TMP_Text dialogText;

    // Counter flow dialog 
    public int dialogCounterPlayer;
    

    void Start()
    {
        Invoke("ActiveDialogPanel",2);
        // invoke text program sequence
        StartCoroutine("DialogText","Vale!!, no te preocupes, ahora salgo a rescatarla...");   
        // startcoroutine wait seconds
        StartCoroutine("WaitSeconds",8);
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
    private void ActiveDialogPanel()
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
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < textDialog.Length; i++)
        {
            dialogText.text += textDialog[i];
            yield return new WaitForSeconds(0.05f);
        }
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
            StartCoroutine("DialogText","Dice que se quiere casar con el Jonathan, el hijo de la Paqui...");
            StartCoroutine("WaitSeconds", 1);
        }
        if (dialogCounterPlayer == 2)
        {
            StartCoroutine("DialogText","Esa familia son todos unos perros. No dan palo al agua!!!...");
            StartCoroutine("WaitSeconds", 1);
        }
        if (dialogCounterPlayer == 3)
        {
            StartCoroutine("DialogText","Así que ve a por ella antes de que me la preñen. VE!!!");
            StartCoroutine("WaitSeconds", 1);
        }
        if (dialogCounterPlayer == 4)
        {
            CloseDialogPanel();
            // activate dialogPlayer object
          //  dialogPlayer.SetActive(true);
            
        }
    }
}
