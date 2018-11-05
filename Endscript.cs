using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endscript : MonoBehaviour {
    public string scene;
    // Use this for initialization
    public bool audioOn = false;
    public AudioClip audioEnd;
    AudioSource scourceAudioEnd;

    void Start () {
        scourceAudioEnd = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.name == "Goldblock")
        {
            collision.gameObject.tag = "Won";

            StartCoroutine("LoadScene");
        }
    }

    IEnumerator LoadScene()
    {
        if (audioOn == true) {
            scourceAudioEnd.PlayOneShot(audioEnd, 1f);
        }
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(scene);
    }
}
