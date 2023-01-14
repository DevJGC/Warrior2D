using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveDataScript : MonoBehaviour
{
    public int totalCoins=0;
    public int totalDiamonds=0;
    public int level=0;

    // Niveles jugados
    public int levelCompleted1;
    public int levelCompleted2;
    public int levelCompleted3;
    public int levelCompleted4;
    public int levelCompleted5;
    public int levelCompleted6;
    public int levelCompleted7;
    public int levelCompleted8;
    public int levelCompleted9;




    bool firstLoad=true;

    void Awake()
    {
        if (PlayerPrefs.HasKey("totalCoins"))
        {
            firstLoad = true;
            totalCoins = PlayerPrefs.GetInt("totalCoins");
            totalDiamonds = PlayerPrefs.GetInt("totalDiamonds");
            level = PlayerPrefs.GetInt("level");
        }
        else
        {
            firstLoad = false;
        }

        FirstLoad();
        

    }
    
    void Start()
    {
        Debug.Log("totalCoins: " + totalCoins);
        Debug.Log("totalDiamonds: " + totalDiamonds);
        Debug.Log("level: " + level);
        Debug.Log("firstLoad: " + firstLoad);

        // Chequeados de niveles jugados
        levelCompleted1 = PlayerPrefs.GetInt("LevelCompleted1");
        levelCompleted2 = PlayerPrefs.GetInt("LevelCompleted2");
        levelCompleted3 = PlayerPrefs.GetInt("LevelCompleted3");
        levelCompleted4 = PlayerPrefs.GetInt("LevelCompleted4");
        levelCompleted5 = PlayerPrefs.GetInt("LevelCompleted5");
        levelCompleted6 = PlayerPrefs.GetInt("LevelCompleted6");
        levelCompleted7 = PlayerPrefs.GetInt("LevelCompleted7");
        levelCompleted8 = PlayerPrefs.GetInt("LevelCompleted8");
        levelCompleted9 = PlayerPrefs.GetInt("LevelCompleted9");

        
    }

    
    void Update()
    {

        // Reset manual PlayerPrefs
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("level", 1); 
            PlayerPrefs.SetInt("totalCoins", 0);
            PlayerPrefs.SetInt("totalDiamonds", 0); 

            PlayerPrefs.SetInt("LevelCompleted1",1);
            PlayerPrefs.SetInt("LevelCompleted2",0);
            PlayerPrefs.SetInt("LevelCompleted3",0);
            PlayerPrefs.SetInt("LevelCompleted4",0);
            PlayerPrefs.SetInt("LevelCompleted5",0);
            PlayerPrefs.SetInt("LevelCompleted6",0);
            PlayerPrefs.SetInt("LevelCompleted7",0);
            PlayerPrefs.SetInt("LevelCompleted8",0);
            PlayerPrefs.SetInt("LevelCompleted9",0);
        }
        
    }

    public void FirstLoad()
    {
        // Primera Carga de Datos
        if (firstLoad==false)
        {
            PlayerPrefs.SetInt("totalCoins", 0);
            PlayerPrefs.SetInt("totalDiamonds", 0);
            PlayerPrefs.SetInt("level", 1);    

            // Chequeados de niveles jugados
            PlayerPrefs.SetInt("LevelCompleted1",0);
            PlayerPrefs.SetInt("LevelCompleted2",0);
            PlayerPrefs.SetInt("LevelCompleted3",0);
            PlayerPrefs.SetInt("LevelCompleted4",0);
            PlayerPrefs.SetInt("LevelCompleted5",0);
            PlayerPrefs.SetInt("LevelCompleted6",0);
            PlayerPrefs.SetInt("LevelCompleted7",0);
            PlayerPrefs.SetInt("LevelCompleted8",0);
            PlayerPrefs.SetInt("LevelCompleted9",0);

        }

    }

}
