using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon1sc : MonoBehaviour {

	public GameObject Enemy1;
	public GameObject Enemy2;

	public int Count1e;
	public int Count2e;

	// Use this for initialization
	void Start () {
		GameManager.instance.Lenemyscounter ();

		Count1e =GameManager.instance.enemy1count;
		Count2e = GameManager.instance.enemy2count;

		if (Count1e <= 0) {
			Count1e = 7;
			GameManager.instance.enemy1count = 7;
			GameManager.instance.Senemyscounter ();
		}
		if (Count2e <= 0) {
			Count2e = 5;
			GameManager.instance.enemy1count = 7;
			GameManager.instance.Senemyscounter ();
		}

		for (int i = 0; i < Count1e; i++) {
			GameObject enemy = Instantiate(Enemy1) as GameObject;
			enemy.transform.position = new Vector3(Random.Range(-129,23),0.5f, Random.Range(-118,8));
		}
		for (int i = 0; i < Count2e; i++) {
			GameObject enemy2 = Instantiate(Enemy2) as GameObject;
			enemy2.transform.position = new Vector3(Random.Range(100,200),0.5f, Random.Range(0,100));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
