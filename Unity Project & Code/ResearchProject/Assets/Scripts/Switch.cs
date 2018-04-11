using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    // Public GameObject to hold the platform the switch relates to
    public GameObject platform;

	// Use this for initialization
	void Start ()
    {
        // Set the platform relevant to the current switch to be inactive
        platform.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    // Trigger checker for entering the collider
    void OnTriggerEnter(Collider other)
    {
        // If the player enters the switch trigger and presses the interact button, open the path
        if (other.tag == "Player" && Input.GetButton("SwitchInteract"))
        {
            Debug.Log("LEVEL CLEAR");
            OpenPath();
        }
    }

    // Trigger checker for staying in the collider
    void OnTriggerStay(Collider other)
    {
        // If the player is in the switch trigger and presses the interact button, open the path
        if (other.tag == "Player" && Input.GetButton("SwitchInteract"))
        {
            Debug.Log("LEVEL CLEAR");
            OpenPath();
        }
    }

    // Function for opening the platform relevant for the current switch
    void OpenPath()
    {
        platform.SetActive(true);
    }
}
