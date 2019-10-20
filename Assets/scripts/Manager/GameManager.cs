using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int battleEnemyID;
	public int enemy1count;
	public int enemy2count;

	public bool FtownL;

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
		enemy1count = PlayerPrefs.GetInt ("count1",7);
		enemy2count = PlayerPrefs.GetInt ("count2",5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Senemyscounter(){
		PlayerPrefs.SetInt ("count1", enemy1count);
		PlayerPrefs.SetInt ("count2", enemy2count);
		PlayerPrefs.Save ();
	}

	public void Lenemyscounter(){
		enemy1count = PlayerPrefs.GetInt ("count1",7);
		enemy2count = PlayerPrefs.GetInt ("count2",5);
	}
}
