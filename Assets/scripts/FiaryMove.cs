using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiaryMove : MonoBehaviour {
	float speed = 0.4f;
	int rotespeed= 2;

	private Animator Fairymove;

	// Use this for initialization
	void Start () {
		Fairymove = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//主人公の移動
		Fairymove.SetBool ("is_walking", false);
		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate (Vector3.forward * speed);
			Fairymove.SetBool ("is_walking", true);
		}

		if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate(Vector3.forward * -speed);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0,rotespeed,0);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0,-rotespeed,0);
		}
	}
}
