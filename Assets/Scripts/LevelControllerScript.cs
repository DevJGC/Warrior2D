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
            if (i == level)
            {
                levelsObjects[i].SetActive(false);
            }
            else
            {
                levelsObjects[i].SetActive(true);
            }
        }
        
    }

    
    void Update()
    {
        
    }
}
