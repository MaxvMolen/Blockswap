using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorscript : MonoBehaviour {
    public GameObject ConnectedTo;
    bool active;
    bool deactive;

	// Use this for initialization
	void Start () {
        deactive = ConnectedTo.GetComponentInChildren<ButtonScript>().pressed;
        this.GetComponent<Animator>().SetBool("Open", false);
    }
	
	// Update is called once per frame
	void Update () {

        active = ConnectedTo.GetComponentInChildren<ButtonScript>().pressed;

        if (active == true && deactive == true)
        {
            Activate();
            deactive = false;
        }
        if (active == false && deactive == false)
        {
            Deactivate();
            deactive = true;
        }
	}

    void Activate ()
    {
        this.GetComponent<Animator>().SetBool("Open", true);
    }

    void Deactivate ()
    {
        this.GetComponent<Animator>().SetBool("Open", false);
    }
}
