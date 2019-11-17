using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon1sc : MonoBehaviour {

	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;
	public GameObject Enemy4;

	public int Count1e;
	public int Count2e;
	public int Count3e;
	public int Count4e;

	// Use this for initialization
	void Start () {
		GameManager.instance.Lenemyscounter ();

		Count1e =GameManager.instance.enemy1count;
		Count2e = GameManager.instance.enemy2count;
		Count3e = GameManager.instance.enemy3count;
		Count4e = GameManager.instance.enemy4count;

		if (Count1e <= 0) {
			Count1e = 7;
			GameManager.instance.enemy1count = 7;
			GameManager.instance.Senemyscounter ();
		}
		if (Count2e <= 0) {
			Count2e = 5;
			GameManager.instance.enemy2count = 5;
			GameManager.instance.Senemyscounter ();
		}
		if (Count3e <= 0) {
			Count3e = 3;
			GameManager.instance.enemy3count = 3;
			GameManager.instance.Senemyscounter ();
		}
		if (Count4e <= 0) {
			Count4e = 6;
			GameManager.instance.enemy3count = 6;
			GameManager.instance.Senemyscounter ();
		}

		for (int i = 0; i < Count1e; i++) {
			GameObject enemy = Instantiate(Enemy1) as GameObject;
			enemy.transform.position = new Vector3(Random.Range(-129,23),0.5f, Random.Range(-118,8));
			//enemy.transform.rotation = Quaternion.Euler (-90,0,0);
		}
		for (int i = 0; i < Count2e; i++) {
			GameObject enemy2 = Instantiate(Enemy2) as GameObject;
			enemy2.transform.position = new Vector3(Random.Range(100,200),0.5f, Random.Range(0,100));
		}
		for (int i = 0; i < Count3e; i++) {
			GameObject enemy3 = Instantiate(Enemy3) as GameObject;
			enemy3.transform.position = new Vector3(Random.Range(-110, 0),0.5f, Random.Range(315,360));
		}
		for (int i = 0; i < Count4e; i++) {
			GameObject enemy4 = Instantiate(Enemy4) as GameObject;
			enemy4.transform.position = new Vector3(Random.Range(-65, 60),0.5f, Random.Range(65,120));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
