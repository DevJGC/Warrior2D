using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasLevelControl : MonoBehaviour
{
    
    public GameObject[] levelButtons;
    public int level=1;


    void Awake()
    {
        PlayerPrefs.SetInt("level", 1);

        level = PlayerPrefs.GetInt("level");
        Debug.Log(level);
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
        
    }

    // Update is called once per frame
    void Update()
    {
 
        
    }

    public void LevelSelect(string levelName)
    {
        
        SceneManager.LoadScene(levelName);

    }
}
