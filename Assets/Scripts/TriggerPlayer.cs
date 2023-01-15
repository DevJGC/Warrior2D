using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //[SerializeField] GameObject particleCheckPoint;
    [SerializeField] ParticleSystem particleCheckPoint;


    // Particle final level
    [SerializeField] ParticleSystem particleFinalLevel;

    // Referencia canvas LevelCompleted
    [SerializeField] GameObject levelCompletedCanvas;

    

    // Mira el valorLevel del Finish actual
    [SerializeField] ValueLevelFinish[] valueLevelFinish;
    int actualLevelFinish;
    int level;

    void Awake() 
    {
        level = PlayerPrefs.GetInt("level");
    }
    


    void Start()
    {

        // Mira el valorLevel del Finish actual
        actualLevelFinish = valueLevelFinish[level].myLevel;
        Debug.Log("Valor actualLevelFinish: " + actualLevelFinish);

        // Particle
       // particleCheckPoint.gameObject.AddComponent<BoxCollider2D>();

 

        // find particlecheckpoint object



        
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

        if (collision.gameObject.tag == "CheckPoint")
        {

            audioSource.PlayOneShot(checkPointSound);
            //particleCheckPoint.SetActive(true);
            particleCheckPoint.Play();

            //player.checkPoint = collision.gameObject.transform.position;
            Destroy(collision.gameObject.GetComponent<BoxCollider2D>(),1f);
        }    

        // Finish
        if (collision.gameObject.tag == "Finish")
        {
            // Mira el valorLevel del Finish actual
            // active particle final level
            particleFinalLevel.Play();
            actualLevelFinish = valueLevelFinish[level].myLevel;
            Debug.Log("Valor actualLevelFinish: " + actualLevelFinish);

            // CheckLevelsPlayfabs
            CheckLevelsPlayfabs();

            // Corutine
           StartCoroutine(LoadSceneLevels());

        }

    }

    // Corutine scenemanagement
    IEnumerator LoadSceneLevels()
    {
        // Start Particle
        particleFinalLevel.Play();
        // Play sound
        audioSource.PlayOneShot(finalLevelSound);

        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene("Levels");
        levelCompletedCanvas.SetActive(true);
    }

    public void CheckLevelsPlayfabs()
    {
        if (actualLevelFinish==1)
        {
            PlayerPrefs.SetInt("LevelCompleted1",1);
        }
        
        if (actualLevelFinish==2)
        {
            PlayerPrefs.SetInt("LevelCompleted2",1);
        }

        if (actualLevelFinish==3)
        {
            PlayerPrefs.SetInt("LevelCompleted3",1);
        }

        if (actualLevelFinish==4)
        {
            PlayerPrefs.SetInt("LevelCompleted4",1);
        }

        if (actualLevelFinish==5)
        {
            PlayerPrefs.SetInt("LevelCompleted5",1);
        }

        if (actualLevelFinish==6)
        {
            PlayerPrefs.SetInt("LevelCompleted6",1);
        }

        if (actualLevelFinish==7)
        {
            PlayerPrefs.SetInt("LevelCompleted7",1);
        }

        if (actualLevelFinish==8)
        {
            PlayerPrefs.SetInt("LevelCompleted8",1);
        }

        if (actualLevelFinish==9)
        {
            PlayerPrefs.SetInt("LevelCompleted9",1);
        }


    }

    


}
