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
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime; // Continually applies gravity to the player, even when the terrain has been deformed
        controller.Move(moveDirection * Time.deltaTime); // Move the player

        // Retrieve the current position of the player, for terrain deformation purposes
        //currentPosition = transform.position;

        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetButton("LevelReset"))
        {
            if (SceneManager.GetActiveScene().name == "Demo Level")
            {
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 2")
            {
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level 2");
            }
            else if (SceneManager.GetActiveScene().name == "Demo Level 3")
            {
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Demo Level 3");
            }
            else if (SceneManager.GetActiveScene().name == "Level 1")
            {
                CraterMaker.done = true;
                TextureChanger.texDone = true;
                tChange.textureReset();
                cMaker.craterReset();
                SceneManager.LoadScene("Level 1");
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