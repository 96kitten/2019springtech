using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossalive : MonoBehaviour {

	public GameObject Boss;
	public GameObject Smokes;

	// Use this for initialization
	void Start () {
		if(GameManager.instance.bosscount == 1){
			Destroy (Boss);
			Destroy (Smokes);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
