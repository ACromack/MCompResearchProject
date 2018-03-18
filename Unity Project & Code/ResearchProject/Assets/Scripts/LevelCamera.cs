using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour {

    public GameObject target;
    private float speedMod = 0.5f;
    private Vector3 point;
    //private Renderer terrRefRend;

	// Use this for initialization
	void Start () {
        point = target.transform.position;
        point.x += 50;
        point.z += 50;
        //point = target.GetComponent<Renderer>().bounds.center;
        transform.LookAt(point);
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
	}
}
