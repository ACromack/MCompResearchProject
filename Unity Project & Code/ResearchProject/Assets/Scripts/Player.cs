using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static public Vector3 currentPosition;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

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
    }
}
