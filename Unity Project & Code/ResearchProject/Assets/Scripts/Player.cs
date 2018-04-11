using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Variables relating the player's movement and terrain deformation
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

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Check to ensure the player is on the ground
        if (controller.isGrounded)
        {
            // Move the player character with respect to the controls they have input
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Retrieve the current position of the player, for terrain deformation purposes
            currentPosition = transform.position;

            // Check for if the player presses the jump button, executes the command and logs it's usage
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                timesJumped++;
            }

        }
        moveDirection.y -= gravity * Time.deltaTime; // Continually applies gravity to the player, even when the terrain has been deformed
        controller.Move(moveDirection * Time.deltaTime); // Move the player


        // Check for whether the player is resetting the level
        // Logs the information up until the reset, resets the terrain deformation and reloads the level
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetButton("LevelReset"))
        {
            timesReset++;
            if (SceneManager.GetActiveScene().name == "Demo Level")
            {
                projLogger.endTimer("Demo Level 1", timesReset, timesJumped, cMaker.upDeformUsage, cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 2")
            {
                projLogger.endTimer("Demo Level 2", timesReset, timesJumped, cMaker.upDeformUsage, cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level 2");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 3")
            {
                projLogger.endTimer("Demo Level 3", timesReset, timesJumped, cMaker.upDeformUsage, cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Level1")
            {
                projLogger.endTimer("Level 1", timesReset, timesJumped, cMaker.upDeformUsage, cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Level1");
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                projLogger.endTimer("Level 2", timesReset, timesJumped, cMaker.upDeformUsage, cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Level2");
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                projLogger.endTimer("Level 3", timesReset, timesJumped, cMaker.upDeformUsage, cMaker.downDeformUsage);
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("ENDGAME");
            }


        }
    }

    // Trigger checker for entering the collider
    void OnTriggerEnter(Collider other)
    {
        // If the player enters a 'Blocker' area they are prevented from using their terrain deformation
        if (other.tag == "Blocker")
        {
            tChange.tdBlocked = true;
            cMaker.tdBlocked = true;
        }

    }

    // Trigger checker for exiting a collider
    void OnTriggerExit(Collider other)
    {
        // If the player exits a 'Blocker' area they are once again allowed to use terrain deformation
        if (other.tag == "Blocker")
        {
            tChange.tdBlocked = false;
            cMaker.tdBlocked = false;
        }
    }
}