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

	public bool mi1;
	public bool mi3;
	public bool mi4;
	public bool mi5;
	public bool mi6;

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

		if (mi1 == false) {
			Destroy (MI1);
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
	}
}
