using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover_MainGame : MonoBehaviour {

    PlayerTakeDamage player;
    bool Isdying = false;
    bool PlayDeathSE = true;


    AudioSource playerDeath;
    AudioSource BGM;


    private void Start()
    {
        PlayDeathSE = true;
        Isdying = false;
        player = GameObject.FindObjectOfType<PlayerTakeDamage>();
        playerDeath = GameObject.Find("playerDeath").GetComponent<AudioSource>();
        BGM = GameObject.Find("GameBGM").GetComponent<AudioSource>();
    }

    void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    SceneManager.LoadScene(2);
        //}

        if (player.IsDead() && PlayDeathSE)
        {
            BGM.Stop();
            PlayDeathSE = false;
            Isdying = true;
            playerDeath.Play();
        }

        if (Isdying == true && !playerDeath.isPlaying)
        {
            SceneManager.LoadScene(2);
        }
	}
}
