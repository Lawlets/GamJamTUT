using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover_Title : MonoBehaviour
{

    public GameObject pauseUI;
    public paugeGame pg;

    public AudioSource BGM;


    public void OnResumeButton()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
        pg.gamePauseState = paugeGame.PAUSESTATE.GAME_IS_RUNNING;

        if (BGM.clip != null)
            BGM.Play();


    }


    public void StartButtonCaller()
    {
        SceneManager.LoadScene("BetaScene");
    }

    public void ExitButtonCaller()
    {
        Application.Quit();
    }
}


