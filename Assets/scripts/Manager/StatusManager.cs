using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

	public int PlayerHP = 20;
	public int PlayerMP = 30;

	public int MAXHP = 20;
	public int MAXMP = 30;

	public bool RestS;


	public Vector3 playerpos;
	public Quaternion playerrote;

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
		MAXHP = PlayerPrefs.GetInt ("MHP",20);
		MAXMP = PlayerPrefs.GetInt ("MMP",30);
		RestS = true;
		playerpos = new Vector3 (33,1,-15);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Status (){
		PlayerPrefs.SetInt ("HP", PlayerHP);
		PlayerPrefs.SetInt ("MP", PlayerMP);
		PlayerPrefs.Save ();
	}

	public void BattleStart (){
		PlayerHP = PlayerPrefs.GetInt ("HP", 20);
		PlayerMP = PlayerPrefs.GetInt ("MP", 30);
	}

	public void SaveMaxStatus(){
		PlayerPrefs.SetInt ("MHP",MAXHP);
		PlayerPrefs.SetInt ("MMP",MAXMP);
		PlayerPrefs.Save ();
	}

	public void LoadMaxStatus(){
		MAXHP = PlayerPrefs.GetInt ("MHP",20);
		MAXMP = PlayerPrefs.GetInt ("MMP",30);
	}

	public void hprecovery () {
		LoadMaxStatus ();
		PlayerHP = MAXHP;
		PlayerMP = MAXMP;
		PlayerPrefs.SetInt ("HP", PlayerHP);
		PlayerPrefs.SetInt ("MP", PlayerMP);
		PlayerPrefs.Save ();
	}
		
}
