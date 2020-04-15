using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{  
    public Text scoreText, scoreText1;
    public GameObject info;
    public AudioSource buttonClick;

    public void Start() 
    {
            
    }
    
    public void Home()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Start");
        Time.timeScale=1;
    }

    public void OpenInfo()
    {
        buttonClick.Play();
        info.SetActive(true);
    }

    public void DoExitGame() 
    {
        buttonClick.Play();
        Application.Quit();
    }

    public void CloseInfo()
    {
        buttonClick.Play();
        info.SetActive(false);
    }

    public void Play()
    {
        buttonClick.Play();
        SceneManager.LoadScene("Intro");
    }
    public void ReStart()
    {
        buttonClick.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        scoreText.GetComponent<GameScore>().Score=0;
        scoreText1.GetComponent<GameScore>().Score=0;
    }

    // Update is called once per frame
    void Update()
    {
         
    }
    
}
