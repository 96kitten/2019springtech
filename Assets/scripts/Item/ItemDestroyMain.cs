using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemDestroyMain : MonoBehaviour {

	public static ItemDestroyMain instance;

	void Awake(){
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	public int hi1;
	public int hi2;
	public int hi3;
	public int hi4;

	public int mi1;
	public int mi3;
	public int mi4;
	public int mi5;
	public int mi6;

	GameObject HI1;
	GameObject HI2;
	GameObject HI3;
	GameObject HI4;

	GameObject MI1;
	GameObject MI3;
	GameObject MI4;
	GameObject MI5;
	GameObject MI6;

	// Use this for initialization
	void Start () {

		Loadingitemprefs ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void destitemM(){
		HI1 = GameObject.Find ("HPitem1");
		HI2 = GameObject.Find ("HPitem2");
		HI3 = GameObject.Find ("HPitem3");
		HI4 = GameObject.Find ("HPitem4");

		MI1 = GameObject.Find ("MPitem1");
		MI3 = GameObject.Find ("MPitem3");
		MI4 = GameObject.Find ("MPitem4");
		MI5 = GameObject.Find ("2MPitem4");
		MI6 = GameObject.Find ("2MPitem3");
		if (hi1 == 0) {
			Destroy (HI1);
		}
		if (hi2 == 0) {
			Destroy (HI2);
		}
		if (hi3 == 0) {
			Destroy (HI3);
		}
		if (hi4 == 0) {
			Destroy (HI4);
		}
		if (mi1 == 0) {
			Destroy (MI1);
		}
		if (mi3 == 0) {
			Destroy (MI3);
		}
		if (mi4 == 0) {
			Destroy (MI4);
		}
		if (mi5 == 0) {
			Destroy (MI5);
		}
		if (mi6 == 0) {
			Destroy (MI6);
		}
			
	}

	public void Loaditemprefs(){
		PlayerPrefs.SetInt ("HiteM1",hi1);
		PlayerPrefs.SetInt ("HiteM2",hi2);
		PlayerPrefs.SetInt ("HiteM3",hi3);
		PlayerPrefs.SetInt ("HiteM4",hi4);
		PlayerPrefs.SetInt ("MiteM1",mi1);
		PlayerPrefs.SetInt ("MiteM3",mi3);
		PlayerPrefs.SetInt ("MiteM4",mi4);
		PlayerPrefs.SetInt ("MiteM5",mi5);
		PlayerPrefs.SetInt ("MiteM6",mi6);
		PlayerPrefs.Save ();
	}

	public void Loadingitemprefs(){
		hi1 = PlayerPrefs.GetInt ("HiteM1",1);
		hi2 = PlayerPrefs.GetInt ("HiteM2",1);
		hi3 = PlayerPrefs.GetInt ("HiteM3",1);
		hi4 = PlayerPrefs.GetInt ("HiteM4",1);
		mi1 = PlayerPrefs.GetInt ("MiteM1",1);
		mi3 = PlayerPrefs.GetInt ("MiteM3",1);
		mi4 = PlayerPrefs.GetInt ("MiteM4",1);
		mi5 = PlayerPrefs.GetInt ("MiteM5",1);
		mi6 = PlayerPrefs.GetInt ("MiteM6",1);
	}
}
