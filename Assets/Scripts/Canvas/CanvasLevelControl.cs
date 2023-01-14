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
       
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i +2 > level)
            {
                levelButtons[i].SetActive(false);
            }
        }

        SynCanvas();
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
    }

    public void LevelSelect(string levelName)
    {
        
        SceneManager.LoadScene(levelName);

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

}
