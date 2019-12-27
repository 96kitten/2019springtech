using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int battleEnemyID;
	public int enemy1count;
	public int enemy2count;
	public int enemy3count;
	public int enemy4count;
	public int bosscount;
	public int Gold;

	public int FtownL;

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
		enemy3count = PlayerPrefs.GetInt ("count3",3);
		enemy4count = PlayerPrefs.GetInt ("count4",6);
		bosscount = PlayerPrefs.GetInt ("Bcount",1);
		FtownL = PlayerPrefs.GetInt ("town1ta", 0);
		Gold = PlayerPrefs.GetInt ("GOLD",0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Senemyscounter(){
		PlayerPrefs.SetInt ("count1", enemy1count);
		PlayerPrefs.SetInt ("count2", enemy2count);
		PlayerPrefs.SetInt ("count3", enemy3count);
		PlayerPrefs.SetInt ("count4", enemy4count);
		PlayerPrefs.SetInt ("Bcount",bosscount);
		PlayerPrefs.Save ();
	}

	public void Lenemyscounter(){
		enemy1count = PlayerPrefs.GetInt ("count1",7);
		enemy2count = PlayerPrefs.GetInt ("count2",5);
		enemy3count = PlayerPrefs.GetInt ("count3",3);
		enemy4count = PlayerPrefs.GetInt ("count4",6);
		bosscount = PlayerPrefs.GetInt ("Bcount",1);
	}

	public void FiTown(){
		PlayerPrefs.SetInt ("town1ta", FtownL);
		PlayerPrefs.Save ();
	}

	public void FiTownL(){
		FtownL = PlayerPrefs.GetInt ("town1ta", 0);
	}

	public void SaveGold(){
		PlayerPrefs.SetInt ("GOLD",Gold);
		PlayerPrefs.Save ();
	}

	public void LoadGold(){
		Gold = PlayerPrefs.GetInt ("GOLD",0);
	}
}
