using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

    public GameObject platform;

	// Use this for initialization
	void Start () {
        platform.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("SwitchInteract"))
        {
            Debug.Log("LEVEL CLEAR");
            OpenPath();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetButton("SwitchInteract"))
        {
            Debug.Log("LEVEL CLEAR");
            OpenPath();
        }
    }

    void OpenPath()
    {
        platform.SetActive(true);
    }
}
