using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover_Title : MonoBehaviour
{
  

    public void StartButtonCaller()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitButtonCaller()
    {
        Application.Quit();
    }
}


