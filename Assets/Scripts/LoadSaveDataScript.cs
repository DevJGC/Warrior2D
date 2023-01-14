using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSaveDataScript : MonoBehaviour
{
    public int totalCoins=0;
    public int totalDiamonds=0;
    public int level=0;

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
        
    }

    
    void Update()
    {
        
    }

    public void FirstLoad()
    {
        if (firstLoad==false)
        {
            PlayerPrefs.SetInt("totalCoins", 0);
            PlayerPrefs.SetInt("totalDiamonds", 0);
            PlayerPrefs.SetInt("level", 1);         
        }

    }

}
