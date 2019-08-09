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

	public bool hi1;
	public bool hi2;
	public bool hi3;
	public bool hi4;
	public bool hi5;

	public bool mi1;
	public bool mi2;
	public bool mi3;
	public bool mi4;
	public bool mi5;
	public bool mi6;
	public bool mi7;

	GameObject HI1;
	GameObject HI2;
	GameObject HI3;
	GameObject HI4;
	GameObject HI5;

	GameObject MI1;
	GameObject MI2;
	GameObject MI3;
	GameObject MI4;
	GameObject MI5;
	GameObject MI6;
	GameObject MI7;

	// Use this for initialization
	void Start () {
		hi1 = true;
		hi2 = true;
		hi3 = true;
		hi4 = true;
		hi5 = true;

		mi1 = true;
		mi2 = true;
		mi3 = true;
		mi4 = true;
		mi5 = true;
		mi6 = true;
		mi7 = true;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void destitemM(){
		HI1 = GameObject.Find ("HPitem1");
		HI2 = GameObject.Find ("HPitem2");
		HI3 = GameObject.Find ("HPitem3");
		HI4 = GameObject.Find ("HPitem4");
		HI5 = GameObject.Find ("3HPitem2");

		MI1 = GameObject.Find ("MPitem1");
		MI2 = GameObject.Find ("MPitem2");
		MI3 = GameObject.Find ("MPitem3");
		MI4 = GameObject.Find ("MPitem4");
		MI5 = GameObject.Find ("2MPitem4");
		MI6 = GameObject.Find ("2MPitem3");
		MI7 = GameObject.Find ("3MPitem3");
		if (hi1 == false) {
			Destroy (HI1.gameObject);
		}
		if (hi2 == false) {
			Destroy (HI2);
		}
		if (hi3 == false) {
			Destroy (HI3);
		}
		if (hi4 == false) {
			Destroy (HI4);
		}
		if (hi5 == false) {
			Destroy (HI5);
		}

		if (mi1 == false) {
			Destroy (MI1);
		}
		if (mi2 == false) {
			Destroy (MI2);
		}
		if (mi3 == false) {
			Destroy (MI3);
		}
		if (mi4 == false) {
			Destroy (MI4);
		}
		if (mi5 == false) {
			Destroy (MI5);
		}
		if (mi6 == false) {
			Destroy (MI6);
		}
		if (mi7 == false) {
			Destroy (MI7);
		}
	}
}
