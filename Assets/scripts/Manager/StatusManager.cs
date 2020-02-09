using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

	public int PlayerHP = 20;
	public int PlayerMP = 30;

	public int MAXHP = 20;
	public int MAXMP = 30;

	public bool RestS;

	public int ReMaj4 = 0;
	public int ReMaj5 = 0;
	public int ReMaj6 = 0;

	public int PlAttack = 0;
	public int PlDefence = 0;

	public Vector3 playerpos;
	public Quaternion playerrote;

	public Vector3 ItemPos;
	public Quaternion ItemRote;

	public string NSceNa;

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
		ReMaj4 = PlayerPrefs.GetInt ("RMajic4",0);
		ReMaj5 = PlayerPrefs.GetInt ("RMajic5",0);
		ReMaj6 = PlayerPrefs.GetInt ("RMajic6",0);
		RestS = true;
		playerpos = new Vector3 (33,1,-15);

		PlAttack = PlayerPrefs.GetInt ("PAT",0);
		PlDefence = PlayerPrefs.GetInt ("PDE",0);
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
		
	public void SaveUsemajic(){
		PlayerPrefs.SetInt ("RMajic4",ReMaj4);
		PlayerPrefs.SetInt ("RMajic5",ReMaj5);
		PlayerPrefs.SetInt ("RMajic6",ReMaj6);
		PlayerPrefs.Save ();
	}

	public void LoadUsemajic(){
		ReMaj4 = PlayerPrefs.GetInt ("RMajic4",0);
		ReMaj5 = PlayerPrefs.GetInt ("RMajic5",0);
		ReMaj6 = PlayerPrefs.GetInt ("RMajic6",0);
	}

	public void SaveChengeStatus(){
		PlayerPrefs.SetInt ("PAT",PlAttack);
		PlayerPrefs.SetInt ("PDF",PlDefence);
		PlayerPrefs.Save ();
	}

	public void LoadChengeStatus(){
		PlAttack = PlayerPrefs.GetInt ("PAT",0);
		PlDefence = PlayerPrefs.GetInt ("PDE",0);
	}

}
