using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public float rotationSpeed = 100f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Distance (in angles) to rotate on each frame
        // distance = speed * time
        float angle = rotationSpeed * Time.deltaTime;

        // Rotate on Y
        transform.Rotate(Vector3.up * angle, Space.World);
	}
}
