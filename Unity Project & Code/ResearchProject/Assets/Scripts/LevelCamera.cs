using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour {

    //   public GameObject target;
    //   private float speedMod = 0.5f;
    //   private Vector3 point;
    //   //private Renderer terrRefRend;

    //// Use this for initialization
    //void Start () {
    //       point = target.transform.position;
    //       point.x += 50;
    //       point.z += 50;
    //       //point = target.GetComponent<Renderer>().bounds.center;
    //       transform.LookAt(point);
    //}

    //// Update is called once per frame
    //void Update () {
    //       transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * speedMod);
    //}

    public Vector3 PointToRotateAround = Vector3.zero;
    public Vector3 Axis = Vector3.up;
    public float Speed = 100f;
    public GameObject target;

    void Start()
    {
        this.transform.LookAt(target.transform.position + new Vector3(50, 0, 50));
        PointToRotateAround = target.transform.position + new Vector3(50, 0, 50);
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
            this.transform.LookAt(target.transform.position + new Vector3(50, 0, 50));
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("RightH"))
        {
            var rot = Quaternion.AngleAxis(this.Speed * -Time.deltaTime, this.Axis);
            var v = this.transform.position - this.PointToRotateAround;
            v = rot * v;
            this.transform.position = this.PointToRotateAround + v;
            this.transform.LookAt(target.transform.position + new Vector3(50, 0, 50));
        }
        else
        {
            this.transform.LookAt(target.transform.position + new Vector3(50, 0, 50));
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
