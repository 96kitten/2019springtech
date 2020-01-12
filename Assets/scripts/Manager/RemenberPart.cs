using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemenberPart : MonoBehaviour {

	public ParticleSystem Rem1;
	public ParticleSystem Rem2;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider colision){
		if (colision.name == "Lady Fairy") {
			if(Input.GetKey(KeyCode.Space)){
				WatchScene ();
			}
		}
	}

	void WatchScene(){
		if(SceneManager.GetActiveScene ().name == "MountainTown"){
			if (StatusManager.instance.ReMaj4 == 0) {
				PartPlay ();
			}
		}
		if(SceneManager.GetActiveScene ().name == "BrokenTown"){
			if (StatusManager.instance.ReMaj5 == 0) {
				PartPlay ();
			}
		}
		if(SceneManager.GetActiveScene ().name == "SeaSideTown"){
			if (StatusManager.instance.ReMaj6 == 0) {
				PartPlay ();
			}
		}
	}

	public void PartPlay(){
		Rem1.Play ();
		Rem2.Play ();
		Invoke ("PartStop",3.0f);
	}

	public void PartStop(){
		Rem1.Stop ();
		Rem2.Stop ();
	}
}
