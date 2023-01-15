using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPlay : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        // Press Enter to Play
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayGame();
        }

        // Press Escale to Exit Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            // Exit unity engine
           // UnityEditor.EditorApplication.isPlaying = false;
        }

        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Levels");
        
    }
}
