using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour {

    public Vector3 PointToRotateAround = Vector3.zero;
    public Vector3 Axis = Vector3.up;
    public Vector3 offsetVector;
    public float Speed = 100f;
    public GameObject target;

    void Start()
    {
        this.transform.LookAt(target.transform.position + offsetVector);
        PointToRotateAround = target.transform.position + offsetVector;
    }

    void Update()
    {
        // Check for user rotating the camera left or right
        if (Input.GetKey(KeyCode.RightShift) || Input.GetButton("LeftH"))
        {
            var rot = Quaternion.AngleAxis(this.Speed * Time.deltaTime, this.Axis);
            var v = this.transform.position - this.PointToRotateAround;
            v = rot * v;
            this.transform.position = this.PointToRotateAround + v;
            this.transform.LookAt(target.transform.position + offsetVector);
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("RightH"))
        {
            var rot = Quaternion.AngleAxis(this.Speed * -Time.deltaTime, this.Axis);
            var v = this.transform.position - this.PointToRotateAround;
            v = rot * v;
            this.transform.position = this.PointToRotateAround + v;
            this.transform.LookAt(target.transform.position + offsetVector);
        }
        else
        {
            this.transform.LookAt(target.transform.position + offsetVector);
        }

        // Check for the player zooming the camera
        if(Input.GetButton("ZoomIn"))
        {
            Camera.main.fieldOfView -= 1.0f;
            
        }
        else if(Input.GetButton("ZoomOut"))
        {
            Camera.main.fieldOfView += 1.0f;
        }

    }

}
