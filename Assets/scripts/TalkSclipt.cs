﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkSclipt : MonoBehaviour {

	public Text talk;
	public GameObject mwindow;


	void Start () {
		mwindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Townp") {
			if (other.gameObject.name == "TownLady") {
				GameManager.instance.FiTownL ();
				if(GameManager.instance.FtownL == 0){
					talk.text = "こんにちは、貴女マオーを倒しに行くの？じゃあ、これあげるわ。 スペースキーで貰う";
				mwindow.SetActive (true);
					if(Input.GetKey (KeyCode.Space)){
					ItemManager.instance.mhpi2 += 1;
				    GameManager.instance.FtownL = 1;
					GameManager.instance.FiTown ();
					}
				}
				if (GameManager.instance.FtownL == 1) {
					talk.text = "頑張ってね！";
					mwindow.SetActive (true);
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		mwindow.SetActive (false);
	}
}
