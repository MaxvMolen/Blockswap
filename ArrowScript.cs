using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public Transform player;
    public GameObject Controlled;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Won").Length == 1)
        {
            player = GameObject.FindGameObjectWithTag("Won").transform;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10);
        }

        else if (GameObject.FindGameObjectsWithTag("Played").Length == 1)
        {
            player = GameObject.FindGameObjectWithTag("Played").transform;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 10);
        }
        


    }

    }



