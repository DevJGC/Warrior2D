using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Borrarme : MonoBehaviour
{
    int level;
    [SerializeField] Text text;
    void Awake()
    {
        level = PlayerPrefs.GetInt("level");
        
    }
    void Start()
    {
        text.text = level.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
