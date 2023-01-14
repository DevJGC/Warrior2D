using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using SceneManagement
using UnityEngine.SceneManagement;




public class TriggerPlayer : MonoBehaviour
{
    [SerializeField] PlayerMovement player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip eatSound;

    [SerializeField] AudioClip coinSound;
    [SerializeField] AudioClip checkPointSound;
    [SerializeField] AudioClip finalLevelSound;

    [SerializeField] CheckPoint checkPoint;

    // Particle
    [SerializeField] GameObject particleCheckPoint;

    // Particle final level
    [SerializeField] GameObject particleFinalLevel;

    // Referencia canvas LevelCompleted
    [SerializeField] GameObject levelCompletedCanvas;
    




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Energy")
        {
            audioSource.PlayOneShot(eatSound);
            player.AddEnergy();
            Destroy(collision.gameObject,1f);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            //audioSource.PlayOneShot(eatSound);
            //player.AddEnergy();
            //Destroy(collision.gameObject);
            player.Hurt();

        }

        if (collision.gameObject.tag == "Dead")
        {
            //audioSource.PlayOneShot(eatSound);
            //player.AddEnergy();
            //Destroy(collision.gameObject);
            player.isDie=true;
            player.energy=0f;
            player.Die();

        }

        if (collision.gameObject.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound);

            player.AddCoin();
            Destroy(collision.gameObject,1f);


        }

        if (collision.gameObject.tag == "CheckPoint" && checkPoint.isCheckPoint)
        {

            audioSource.PlayOneShot(checkPointSound);
            particleCheckPoint.SetActive(true);
            //player.checkPoint = collision.gameObject.transform.position;
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>(),1f);
        }    

        // Finish
        if (collision.gameObject.tag == "Finish")
        {
           StartCoroutine(LoadSceneLevels());


        }

    }

    // Corutine scenemanagement
    IEnumerator LoadSceneLevels()
    {
        // Start Particle
        particleFinalLevel.SetActive(true);
        // Play sound
        audioSource.PlayOneShot(finalLevelSound);

        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene("Levels");
        levelCompletedCanvas.SetActive(true);
    }


    


}
