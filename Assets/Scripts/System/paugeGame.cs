using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class paugeGame : MonoBehaviour
{
    GameObject pauseUI;

    AudioSource audioSource;
    AudioSource BGM;

    public enum PAUSESTATE
    {
        GAME_IS_PAUSED,

        GAME_IS_RUNNING
    }

    public PAUSESTATE gamePauseState;

	// Use this for initialization
	void Start ()
    {
        Time.timeScale = 1;
        pauseUI = GameObject.Find("PauseUI");
        pauseUI.SetActive(false);
        gamePauseState = PAUSESTATE.GAME_IS_RUNNING;

        audioSource = GetComponent<AudioSource>();
        BGM = GameObject.Find("GameBGM").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {

        if (gamePauseState == PAUSESTATE.GAME_IS_RUNNING)
        {
            if (Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.U))
            {
                Time.timeScale = 0;
                pauseUI.SetActive(true);
                gamePauseState = PAUSESTATE.GAME_IS_PAUSED;

                if (BGM.clip != null)
                {
                    BGM.Pause();
                }

                if (audioSource.clip != null)
                {
                    audioSource.Play();
                }


            }
        }


        else if (gamePauseState == PAUSESTATE.GAME_IS_PAUSED)
        {
            if (Input.GetButtonDown("Start") || Input.GetKeyDown(KeyCode.U))
            {
                Time.timeScale = 1;
                pauseUI.SetActive(false);
                gamePauseState = PAUSESTATE.GAME_IS_RUNNING;

                if (BGM.clip != null)
                {
                    BGM.Play();
                }
            }
        }

    }

    public void ResumeGameCaller()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        gamePauseState = PAUSESTATE.GAME_IS_RUNNING;
    }

    public void RetrunToTitle()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        gamePauseState = PAUSESTATE.GAME_IS_RUNNING;
        SceneManager.LoadScene(0);
    }

    public void QuiteGame()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        gamePauseState = PAUSESTATE.GAME_IS_RUNNING;
        Application.Quit();
    }
}
