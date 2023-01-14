using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LevelCompletedScript : MonoBehaviour
{
    // Referencia al player para tomar los datos
    [SerializeField] PlayerMovement playerMovement;
    // Variables para guardar los datos
    int coin;
    int diamond;

    // Referencia a los textos
    [SerializeField] TMP_Text textCoinBase;
    [SerializeField] TMP_Text textDiamondBase;
    int coinBase=0;
    int diamondBase=0;

    
    // Contador de tiempo
    //int timeCounter=0;
    float timer=0.0f;
    float seconds=0.0f;

    bool checkPoints;

    // sounds
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip diamondSound;

    
    





    void Start()
    {
        // Guardar los datos del player
        coin = playerMovement.coin;
        diamond = playerMovement.diamond;


    }

    void Update()
    {

        timer += Time.deltaTime;
        seconds = timer % 60;

        if (seconds > 0.2f && checkPoints==false)
        {

            if (coin > coinBase)
            {
                SynCanvasCoins();  
            }

            if (diamond > diamondBase)
            {
                SynCanvasDiamonds();
            }

        Debug.Log("ya!!");

        timer = 0;
        seconds=0;
     
        }

        if (coinBase == coin && diamondBase == diamond)
        {
            checkPoints = true;
        }
        
    }

    private void SynCanvasCoins()
    {
        
        coinBase++;
        textCoinBase.text = coinBase.ToString();
        audioSource.PlayOneShot(coinSound);
    }

    private void SynCanvasDiamonds()
    {
        
        diamondBase++;
        textDiamondBase.text = diamondBase.ToString();
        audioSource.PlayOneShot(diamondSound);
        

    }


}
