using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

	public int PlayerHP = 20;
	public int PlayerMP = 10;

	public Vector3 playerpos;

	public static StatusManager instance;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		PlayerHP = PlayerPrefs.GetInt ("HP", 20);
		PlayerMP = PlayerPrefs.GetInt ("MP", 30);

		playerpos = new Vector3 (33,1,-15);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void Status(){
		PlayerPrefs.SetInt ("HP", PlayerHP);
		PlayerPrefs.SetInt ("MP", PlayerMP);
		PlayerPrefs.Save ();
	}

	public void BattleStart (){
		PlayerHP = PlayerPrefs.GetInt ("HP", 20);
		PlayerMP = PlayerPrefs.GetInt ("MP", 10);
	}
		
}
