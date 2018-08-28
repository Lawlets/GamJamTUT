using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover_MainGame : MonoBehaviour {

    PlayerTakeDamage player;
    bool startMoving = false;


    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerTakeDamage>();
    }

    void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    SceneManager.LoadScene(2);
        //}

        if (player.IsDead())
        {
            SceneManager.LoadScene(2);
        }
	}
}
