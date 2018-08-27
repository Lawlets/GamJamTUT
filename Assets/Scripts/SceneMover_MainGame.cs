using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMover_MainGame : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene(2);
        }
	}
}
