using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemymove : MonoBehaviour {

	private float speed = 3f;

	private float rotationSmooth = 1f;

	private Vector3 targetPosition;

	private float changeTargetSqrDistance = 40f;

	public bool search;

	private Transform player;

	void Start () {
		search = false;
		targetPosition = GetRandomPositionOnLevel();
		player = GameObject.FindWithTag("Player").transform;
	}

	void Update () {

		//徘徊するやつ http://blog.uzutaka.com/entry/2015/10/14/031633 より
		if (search == true) {
//			Vector3 direction = player.transform.position - transform.position;
//			Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
//			transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
			//Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
			//Debug.Log (targetRotation);
			//targetRotation = Quaternion.Euler (0,targetRotation.y,0);
			//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
			transform.LookAt(player.position);
			transform.rotation = Quaternion.Euler (0, this.transform.rotation.eulerAngles.y, 0);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
		if (search == false) {
			float sqrDistanceToTarget = Vector3.SqrMagnitude (transform.position - targetPosition);
			if (sqrDistanceToTarget < changeTargetSqrDistance) {
				targetPosition = GetRandomPositionOnLevel ();
			}
			/*Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
			transform.Translate(Vector3.forward * speed * Time.deltaTime);*/
		}

	}

	public Vector3 GetRandomPositionOnLevel(){
		//目標地点
		float levelSize = 55f;
		return new Vector3(Random.Range(-levelSize, levelSize), 0.5f, Random.Range(-levelSize, levelSize));
	}

	//索敵範囲に入ってきたとき
	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("Player")) {
			search = true;
		}
	}

	void OnTriggerExit (Collider other){
		if (other.CompareTag ("Player")) {
			search = false;
		}
	}
}