using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCon1sc : MonoBehaviour {

	public GameObject enemy1;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++) {
			GameObject enemy = Instantiate(enemy1) as GameObject;
			enemy.transform.position = new Vector3(Random.Range(-129,23),0.5f, Random.Range(-118,8));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
