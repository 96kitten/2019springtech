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

	public float Timer = 0;

	// Use this for initialization
	void Start () {
		talking[0] = "これはこれは、小さな生き物がこんなところまで来たものだな";
		talking[1] = "は、そんななりでこの我を打ち倒そうと？";
		talking[2] = "勇気と無謀を履き違えたか？大層な心持ちのようだ";
		talking[3] = "いい、ではその無謀さで我にかかって来てみせろ";
		talking[4] = "その小さな体ごと叩きのめしてみせよう！";
	}
	
	// Update is called once per frame
	void Update () {
		Timer -= Time.deltaTime;
		if(Timer <= 0){
			Timer = 0;
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			if(Timer <= 0){
			if (talk <= 4) {
				talk += 1;
				Timer = 1;
			}
			if (talk == 5) {
					SceneManager.LoadScene ("BossBattle");
			}
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
