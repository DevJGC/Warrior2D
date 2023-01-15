using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControllerScript : MonoBehaviour
{
    [SerializeField] GameObject[] levelsObjects;
    [SerializeField] int level;

    private void Awake() 
    {
        level = PlayerPrefs.GetInt("level");

    }
    
    void Start()
    {
        for (int i = 0; i < levelsObjects.Length; i++)
        {
            if (i  == level-1)
            {
                levelsObjects[i].SetActive(true);
            }
            else
            {
                levelsObjects[i].SetActive(false);
            }
        }
        
    }

    
    void Update()
    {
        
    }
}
