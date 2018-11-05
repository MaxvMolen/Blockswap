
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class Blocksmanager : MonoBehaviour {

    [SerializeField] GameObject objectWithSerialConnect;

    public bool cycle;
    public int Current;
    public GameObject[] Blocks;
    public GameObject Controlled;
    public bool arduino = false;
    public bool credits = false;
    private SerialConnect myScript;
    public List<int> actValues;
    private static SerialPort serial;

    public float timeButton = 0.3f;
    private float timeDef;
    private int clicks;


    // Use this for initialization
    void Start () {
        timeDef = timeButton;
        Blocks = GameObject.FindGameObjectsWithTag("Player");
        cycle = true;
        if (GameObject.FindGameObjectsWithTag("Played").Length >= 1)
        {
            Debug.LogWarning("More than one player detected, all blocks need the 'player' tag in the editor, this script will take care of the rest");
        }
        myScript = objectWithSerialConnect.GetComponent<SerialConnect>();


    }
	
	// Update is called once per frame
	void Update () {
        actValues = myScript.values;

        Controlled = GameObject.FindGameObjectWithTag("Played");

       
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cycle = true;
            if (credits == true) {
                SceneManager.LoadScene("Main menu");
            }
        }

        teensy();

        if (cycle == true)
        {
            if (Controlled != null)
            {
                Controlled.tag = "Player";
            }

            if (Current < Blocks.Length)
            {
                Blocks[Current].tag = "Played";
                Current++;
                cycle = false;
            }
            else { Current = 0; }
        }

	}

    void teensy() {
        if (arduino == true) {
            if (actValues[4] == 1) {
                timeButton -= Time.deltaTime;
                if (timeButton >= 0) {             
                    clicks++;
                    if (clicks == 1) {
                        cycle = true;
                        if (credits == true) {
                            SceneManager.LoadScene("Main menu");
                        }
                    }
                }
                else {
                    timeButton = timeDef;
                    clicks = 0;
                }
            }
            else {
                timeButton = timeDef;
                clicks = 0;
            }      
        }
    }
}
