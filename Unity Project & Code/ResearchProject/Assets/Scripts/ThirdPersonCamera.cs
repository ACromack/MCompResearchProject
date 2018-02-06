using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    Transform cameraTransform;
    private Transform _target;

    // The distance in the x-z plane to the target

    float distance = 7.0f;

    // the height we want the camera to be above the target
    float height = 3.0f;

    float angularSmoothLag = 0.3f;
    float angularMaxSpeed = 15.0f;

    float heightSmoothLag = 0.3f;

    float snapSmoothLag = 0.2f;
    float snapMaxSpeed = 720.0f;

    float clampHeadPositionScreenSpace = 0.75f;

    float lockCameraTimeout = 0.2f;

    private Vector3 headOffset = Vector3.zero;
    private Vector3 centerOffset = Vector3.zero;

    private float heightVelocity = 0.0f;
    private float angleVelocity = 0.0f;
    private bool snap = false;
    private ThirdPersonController controller;
    private float targetHeight = 100000.0f;

    void Awake()
    {
        if (!cameraTransform && Camera.main)
            cameraTransform = Camera.main.transform;
        if (!cameraTransform)
        {
            Debug.Log("Please assign a camera to the ThirdPersonCamera script.");
            enabled = false;
        }


        _target = transform;
        if (_target)
        {
            //controller = _target.GetComponent(ThirdPersonController);
        }

        if (controller)
        {
            //CharacterController characterController = _target.GetComponent.< Collider > ();
            //centerOffset = characterController.bounds.center - _target.position;
            //headOffset = centerOffset;
            //headOffset.y = characterController.bounds.max.y - _target.position.y;
        }
        else
            Debug.Log("Please assign a target to the camera that has a ThirdPersonController script attached.");


       // Cut(_target, centerOffset);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
