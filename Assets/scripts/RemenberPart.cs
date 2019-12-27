using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemenberPart : MonoBehaviour {

	public ParticleSystem Rem1;
	public ParticleSystem Rem2;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PartPlay(){
		Rem1.Play ();
		Rem2.Play ();
	}
}
