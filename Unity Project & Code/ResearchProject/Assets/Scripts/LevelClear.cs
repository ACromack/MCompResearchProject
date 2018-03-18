using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("LEVEL CLEAR");

            if(SceneManager.GetActiveScene().name == "Demo Level")
            {
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Demo Level 2");
            }
            else if(SceneManager.GetActiveScene().name == "Demo Level 2")
            {
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Demo Level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 3")
            {
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Demo Level");
            }
        }


    }
}
