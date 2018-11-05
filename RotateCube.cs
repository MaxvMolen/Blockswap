using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;   // for the GUI

public class RotateCube : MonoBehaviour {

    [SerializeField] GameObject objectWithSerialConnect;        // the object to which the SerialConnect script is attached

    // what to send to the Arduino when you press the action Button
    private SerialConnect myScript;
 
    // to receive values from the Arduino
    public List<int> actValues;
    public GameObject pointOfMovement; 
    private Quaternion origRot;

    // Use this for initialization
    void Start () {
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();
        origRot = transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        // get values from Arduino
        actValues = myScript.values;
         
        if (actValues.Count >= 4)
        { // (In this case) if a valid measurement
            Quaternion newRot = new Quaternion(actValues[0], -actValues[2], actValues[1], actValues[3]);    // Gidi: since MPU9150 is righthanded and Unity left-handed

            // movement player with use of torque
            if (this.tag == "Played") {
                GameObject.FindWithTag("MainCamera").GetComponent<Blocksmanager>().arduino = true;
                gameObject.GetComponent<RotateCube>().enabled = true;

                if (actValues[1] <= -250) {
                    this.GetComponent<Rigidbody>().AddTorque(pointOfMovement.transform.right * -actValues[1]); //forward
                }

                if (actValues[1] >= 70) {
                    this.GetComponent<Rigidbody>().AddTorque(pointOfMovement.transform.right * -actValues[1]); //back
                }

                if (actValues[0] >= 50) {
                    this.GetComponent<Rigidbody>().AddTorque(pointOfMovement.transform.forward * actValues[0]);  //left
                }

                if (actValues[0] <= -285) {
                    this.GetComponent<Rigidbody>().AddTorque(pointOfMovement.transform.forward * actValues[0]);  //right
                }
                
            }

        }
        else
        {
            GameObject.FindWithTag("MainCamera").GetComponent<Blocksmanager>().arduino = false;
        }

    }
}
