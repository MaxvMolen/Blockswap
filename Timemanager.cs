using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timemanager : MonoBehaviour {
    int sysTime = System.DateTime.Now.Hour;
    Camera cam;
    Light color;
    public Color day;
    public Color night;
    public Color morning;
    public Color evening;

    // Use this for initialization
    void Start () {
        color = this.GetComponent<Light>();
        cam = Camera.main.GetComponent<Camera>();
        if (sysTime <= 6 && sysTime >= 22)
        {
            //night between 22 - 6
            this.transform.rotation = Quaternion.AngleAxis(270, Vector3.right);
            this.transform.Rotate(Vector3.up, -45);
            color.color = Color.black;
            cam.backgroundColor = night;
        }
        if (sysTime == 7 || sysTime == 8 || sysTime == 9)
        {
            //morning between 7 - 9 
            this.transform.rotation = Quaternion.AngleAxis(170, Vector3.right);
            this.transform.Rotate(Vector3.up, -45);
            color.color = Color.yellow;
            cam.backgroundColor = morning;

        }
        if (sysTime == 19 || sysTime == 20 || sysTime == 21)
        {
            //evening between 19 - 21
            this.transform.rotation = Quaternion.AngleAxis(10, Vector3.right);
            this.transform.Rotate(Vector3.up, -45);
            color.color = Color.yellow;
            cam.backgroundColor = evening;
        }
        if (sysTime >= 10 && sysTime <= 17)
        {
            //day between 10 - 17
            this.transform.rotation = Quaternion.AngleAxis(70, Vector3.right);
            this.transform.Rotate(Vector3.up, -45);
            color.color = Color.gray;
            cam.backgroundColor = day;
        }
    }
}
