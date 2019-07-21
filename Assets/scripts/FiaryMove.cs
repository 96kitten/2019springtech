using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FiaryMove : MonoBehaviour {
	float speed = 6;
	int rotespeed= 2;

	private Animator Fairymove;


	// Use this for initialization
	void Start () {
		Fairymove = GetComponent<Animator> ();
		this.gameObject.transform.position = StatusManager.instance.playerpos;
	}
	
	// Update is called once per frame
	void Update () {
		//主人公の移動
		Fairymove.SetBool ("is_walking", false);
		if (Input.GetKey (KeyCode.W)) {
			this.transform.Translate (Vector3.forward * speed * Time.deltaTime);
			Fairymove.SetBool ("is_walking", true);
		}

		if (Input.GetKey (KeyCode.S)) {
			this.transform.Translate(Vector3.forward * -speed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0,rotespeed,0);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0,-rotespeed,0);
		}

	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Enemy") {
			StatusManager.instance.playerpos = this.gameObject.transform.position;
			GameManager.instance.battleEnemyID = 1;
			SceneManager.LoadScene ("Battlescene");
		}
		if (other.gameObject.tag == "Enemy2") {
			StatusManager.instance.playerpos = this.gameObject.transform.position;
			GameManager.instance.battleEnemyID = 2;
			SceneManager.LoadScene ("Battlescene");
		}
	}
}
