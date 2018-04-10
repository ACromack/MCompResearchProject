using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    static public Vector3 currentPosition;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    public TextureChanger tChange;
    public CraterMaker cMaker;

    // Logging variables
    public int timesJumped = 0;
    public int timesReset = 0;
    public ProjectLogging projLogger;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            // Retrieve the current position of the player, for terrain deformation purposes
            currentPosition = transform.position;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                timesJumped++;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime; // Continually applies gravity to the player, even when the terrain has been deformed
        controller.Move(moveDirection * Time.deltaTime); // Move the player

        // Retrieve the current position of the player, for terrain deformation purposes
        //currentPosition = transform.position;

        // Check for whether the player is resetting the level
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetButton("LevelReset"))
        {
            timesReset++;
            if (SceneManager.GetActiveScene().name == "Demo Level")
            {
                projLogger.endTimer("Demo Level 1", timesReset, timesJumped);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 2")
            {
                projLogger.endTimer("Demo Level 2", timesReset, timesJumped);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level 2");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 3")
            {
                projLogger.endTimer("Demo Level 3", timesReset, timesJumped);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Level1")
            {
                projLogger.endTimer("Level 1", timesReset, timesJumped);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Level1");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                projLogger.endTimer("Level 2", timesReset, timesJumped);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                projLogger.endTimer("Level 3", timesReset, timesJumped);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("ENDGAME");
            }


        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blocker")
        {
            tChange.tdBlocked = true;
            cMaker.tdBlocked = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Blocker")
        {
            tChange.tdBlocked = false;
            cMaker.tdBlocked = false;
        }
    }
}