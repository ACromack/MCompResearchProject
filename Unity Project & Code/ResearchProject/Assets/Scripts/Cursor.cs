using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Transform explosion;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Mouse.mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            
        }
    }
}
