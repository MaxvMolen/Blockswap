using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
    public string scene;
    public bool scenes = true;
    public bool quit = false;
    public AudioClip audio;
    AudioSource scourceAudio;
    bool Loading = false;

    void Start () {
        scourceAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision collision)
    {
        if (scenes == true) {
            if (collision.transform.gameObject.name == "Goldblock")
            {
                if (Loading == false) {
                    StartCoroutine(LoadScene());
                    Loading = true;
                }
            }
        }

        if (quit == true)
        {
            if (Loading == false) {
                StartCoroutine(LoadScene());
                Loading = true;
            }
            //Application.Quit();
        }

    }

    IEnumerator LoadScene() {
        scourceAudio.PlayOneShot(audio, 1f);
        yield return new WaitForSeconds(audio.length);
        SceneManager.LoadScene(scene);
    }

    IEnumerator QuitGame() {
        scourceAudio.PlayOneShot(audio, 1f);
        yield return new WaitForSeconds(audio.length);
        Application.Quit();
    }


}
