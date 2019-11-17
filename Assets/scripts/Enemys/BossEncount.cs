using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossEncount : MonoBehaviour {
	int talk = 0;
	string[] talking = new string[5];
	public GameObject Log;
	public Text serif;

	// Use this for initialization
	void Start () {
		talking[0] = "あ";
		talking[1] = "い";
		talking[2] = "う";
		talking[3] = "え";
		talking[4] = "お";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			if (talk <= 4) {
				talk += 1;
			}
			if (talk == 5) {
					SceneManager.LoadScene ("BossBattle");
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "BOSS") {
			talk = 0;
		}
	}

	void OnTriggerStay (Collider other){
		if(other.tag == "BOSS"){
			if (talk <= 3) {
				serif.text = talking [talk];
				Log.SetActive (true);
			}
			if (talk == 4) {
				serif.text = talking [4];
				Log.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider other){
		Log.SetActive (false);
		talk = 0;
	}
}
