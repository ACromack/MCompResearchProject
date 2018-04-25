using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelClear : MonoBehaviour {

    // Public objects to hold the player and logger (Vital for the logging component as it requires information from both these)
    public Player playerCharacter;
    public ProjectLogging clearProjLogger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    // Trigger event for when the player reaches the goal of the level
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("LEVEL CLEAR");

            // If statements to determine what level the player is on
            // Logs the tracked metrics from the play session, resets the terrain deformation and loads the next level
            if (SceneManager.GetActiveScene().name == "Demo Level")
            {
                clearProjLogger.endTimer("Demo Level 1", playerCharacter.timesReset, playerCharacter.timesJumped, playerCharacter.cMaker.upDeformUsage, playerCharacter.cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Demo Level 2");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 2")
            {
                clearProjLogger.endTimer("Demo Level 2", playerCharacter.timesReset, playerCharacter.timesJumped, playerCharacter.cMaker.upDeformUsage, playerCharacter.cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Demo Level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 3")
            {
                clearProjLogger.endTimer("Demo Level 3", playerCharacter.timesReset, playerCharacter.timesJumped, playerCharacter.cMaker.upDeformUsage, playerCharacter.cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Level1");
            }
            else if (SceneManager.GetActiveScene().name == "Level1")
            {
                clearProjLogger.endTimer("Level 1", playerCharacter.timesReset, playerCharacter.timesJumped, playerCharacter.cMaker.upDeformUsage, playerCharacter.cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                clearProjLogger.endTimer("Level 2", playerCharacter.timesReset, playerCharacter.timesJumped, playerCharacter.cMaker.upDeformUsage, playerCharacter.cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("Level3");
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                clearProjLogger.endTimer("Level 3", playerCharacter.timesReset, playerCharacter.timesJumped, playerCharacter.cMaker.upDeformUsage, playerCharacter.cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                SceneManager.LoadScene("ENDGAME");
            }

        }


    }
}
