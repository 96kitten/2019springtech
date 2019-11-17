using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FiaryMove : MonoBehaviour {
	float speed = 6;
	int rotespeed= 2;
	public bool moving;
	private Animator Fairymove;
	public MoveTown movetown;


	// Use this for initialization
	void Start () {
		Fairymove = GetComponent<Animator> ();
		if (SceneManager.GetActiveScene ().name == "Main") {
			this.gameObject.transform.position = StatusManager.instance.playerpos;
			this.gameObject.transform.rotation = StatusManager.instance.playerrote;
		}
		moving = true;
		ItemDestroyMain.instance.destitemM ();
	}
	
	// Update is called once per frame
	void Update () {
		//主人公の移動
		if (moving == true) {
			Fairymove.SetBool ("is_walking", false);
			if (Input.GetKey (KeyCode.W)) {
				this.transform.Translate (Vector3.forward * speed * Time.deltaTime);
				Fairymove.SetBool ("is_walking", true);
			}

			if (Input.GetKey (KeyCode.S)) {
				this.transform.Translate (Vector3.forward * -speed * Time.deltaTime);
			}

			if (Input.GetKey (KeyCode.D)) {
				transform.Rotate (0, rotespeed, 0);
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Rotate (0, -rotespeed, 0);
			}

			if (Input.GetKey (KeyCode.E)) {
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("StatusItemHP");
			}
		}
	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "Enemy") {
			StatusManager.instance.playerpos = this.gameObject.transform.position;
			StatusManager.instance.playerrote = this.gameObject.transform.rotation;
			GameManager.instance.battleEnemyID = 1;
			SceneManager.LoadScene ("Battlescene");
		}
		if (other.gameObject.tag == "Enemy2") {
			StatusManager.instance.playerpos = this.gameObject.transform.position;
			StatusManager.instance.playerrote = this.gameObject.transform.rotation;
			GameManager.instance.battleEnemyID = 2;
			SceneManager.LoadScene ("Battlescene");
		}
		if (other.gameObject.tag == "enemy3") {
			StatusManager.instance.playerpos = this.gameObject.transform.position;
			StatusManager.instance.playerrote = this.gameObject.transform.rotation;
			GameManager.instance.battleEnemyID = 3;
			SceneManager.LoadScene ("Battlescene");
		}
		if (other.gameObject.tag == "Enemy4") {
			StatusManager.instance.playerpos = this.gameObject.transform.position;
			StatusManager.instance.playerrote = this.gameObject.transform.rotation;
			GameManager.instance.battleEnemyID = 4;
			SceneManager.LoadScene ("Battlescene");
		}
	}
		
}
