using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover_GameClear : MonoBehaviour
{
    public void ReturnToTitleCaller()
    {
        SceneManager.LoadScene(0);
    }

    public void QuiteGameCaller()
    {
        Application.Quit();
    }
}
