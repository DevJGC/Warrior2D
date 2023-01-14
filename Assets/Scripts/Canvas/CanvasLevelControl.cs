using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class CanvasLevelControl : MonoBehaviour
{
    
    public GameObject[] levelButtons;
    [SerializeField] int level;

    // PlayerPrefs

    int localTotalCoins;
    int localTotalDiamonds;

    // Canvas
    [SerializeField] TMP_Text textTotalCoins;
    [SerializeField] TMP_Text textTotalDiamonds;


    // REVISAR ESTO!!!

    public int levelCompleted1;
    public int levelCompleted2;
    public int levelCompleted3;
    public int levelCompleted4;
    public int levelCompleted5;
    public int levelCompleted6;
    public int levelCompleted7;
    public int levelCompleted8;
    public int levelCompleted9;


    void Awake()
    {
        // Para cambiar el valor "level" de PlayerPrefs
        //PlayerPrefs.SetInt("level", 1);

        level = PlayerPrefs.GetInt("level");
        localTotalCoins = PlayerPrefs.GetInt("totalCoins");
        localTotalDiamonds = PlayerPrefs.GetInt("totalDiamonds");

        
        // Control manual de niveles
        Debug.Log(level);
       // level = level + 1;
    }
    
    void Start()
    {
       
        // for (int i = 0; i < levelButtons.Length; i++)
        // {
        //     if (i +2 > level)
        //     {
        //         levelButtons[i].SetActive(false);
        //     }
        // }


        // Chequeados de niveles jugados
        LoadLevelCompleted();
        CheckLevelsPlayfabs();

        SynCanvas();
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
    }

    public void LevelSelect(int levelNumber)
    {
        PlayerPrefs.SetInt("level", levelNumber);
        SceneManager.LoadScene("GamePlay");

    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    private void SynCanvas()
    {
        textTotalCoins.text = localTotalCoins.ToString();
        textTotalDiamonds.text = localTotalDiamonds.ToString();
    }


    public void CheckLevelsPlayfabs()
    {
        if (levelCompleted1==1)
        {
            levelButtons[0].SetActive(true);
        }
        
        if (levelCompleted2==1)
        {
            levelButtons[1].SetActive(true);
        }

        if (levelCompleted3==1)
        {
            levelButtons[2].SetActive(true);
        }

        if (levelCompleted4==1)
        {
            levelButtons[3].SetActive(true);
        }

        if (levelCompleted5==1)
        {
            levelButtons[4].SetActive(true);
        }

        if (levelCompleted6==1)
        {
            levelButtons[5].SetActive(true);
        }

        if (levelCompleted7==1)
        {
            levelButtons[6].SetActive(true);
        }

        if (levelCompleted8==1)
        {
            levelButtons[7].SetActive(true);
        }
        // Ojo, final del juego
        if (levelCompleted9==1)
        {
            levelButtons[8].SetActive(true);
        }

    }

    public void LoadLevelCompleted()
    {
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

}
