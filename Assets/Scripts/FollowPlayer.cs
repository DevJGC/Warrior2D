using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    
    [SerializeField] Transform player;



    void Start()
    {
        
    }

    
    void Update()
    {

        transform.position = new Vector3(player.position.x, 0, transform.position.z);

        // Press Escale to Menu Scene
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
        
    }
}
