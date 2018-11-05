using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour {

    Vector3 Origin;
    public bool Isplayer;
    public Rigidbody rb;
    bool Respawning = false;
    bool executing = true;
    public ParticleSystem Exp;
    public ParticleSystem end;
    public ParticleSystem fling;
    public GameObject endportal;
    public Vector3 Move;
    public float speed = 100f;

    public bool cannon = false;

    Cannon cannonObject;
    //public List


    // Use this for initialization
    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();           
        if (end != null)
        {
            this.GetComponent<Animator>().SetBool("play", false);
            end.Stop();
        }
        Origin = transform.position;
        if (cannon == true) {
            cannonObject = GameObject.Find("Cannons").GetComponent<Cannon>();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (rb.velocity.magnitude >= 7)
        {
            fling.Play();
        }
        else if (rb.velocity.magnitude <= 7)
        {
            fling.Stop();
        }

        if (this.transform.position.y <= -10 && Respawning == false)
        {
            Killblock();
            Respawning = true;         

        }

        if (this.tag == "Won")
        {
            rb.useGravity = false;

            if (executing == true)
            {
                rb.drag = 1;
                rb.angularDrag = 1;
                end.Play();
                this.GetComponent<Animator>().SetBool("play", true);
                Invoke("endlevel", 5);
                executing = false;
            }
        }

        if (this.tag == "Played")
        {
            if (Input.GetKey(KeyCode.W)) {
                rb.AddTorque(speed, 0, 0, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.AddTorque(0, 0, speed, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddTorque(-speed, 0, 0, ForceMode.Force);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.AddTorque(0, 0, -speed, ForceMode.Force);
            }
        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.CompareTag("Danger") && Respawning == false) {
            Killblock();
            Respawning = true;
        }
    }

    void OnCollisionStay(Collision col) {
        if (this.name == "Goldblock") {
            if (col.gameObject.CompareTag("Grass") && Respawning == false) {
                cannonObject.ResetTime();
            }
        }
    }
    
    void OnTriggerStay(Collider col) {
        if (this.name == "Goldblock") {
            if (col.gameObject.name == "Cannons" && Respawning == false) {
                col.gameObject.GetComponent<Cannon>().timerCannon = false;
            }
        }
    }

    void endlevel()
    {
        end.Stop();
        rb.isKinematic = true;
        GetComponent<Collider>().enabled = false;
        GetComponent<Renderer>().enabled = false;
    }

    void Killblock()
    {
        this.GetComponent<Renderer>().enabled = false;
        this.rb.isKinematic = true;
        Exp.Play();
        Invoke("Respawn", 4);
    }

    void Respawn()
    {  
        this.GetComponent<Renderer>().enabled = true;
        this.transform.position = Origin;
        this.rb.isKinematic = false;
        Respawning = false;
    }
}
