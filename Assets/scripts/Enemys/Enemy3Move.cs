using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy3Move : MonoBehaviour {

	private float speed = 2f;

	private float rotationSmooth = 3f;

	private Vector3 targetPosition;

	private float changeTargetSqrDistance = 40f;

	public bool search;

	private Transform player;

	public Animator WMoveAnimate;

	void Start () {
		search = false;
		if (SceneManager.GetActiveScene ().name == "Main") {
			targetPosition = GetRandomPositionOnLevel();
			player = GameObject.FindWithTag ("Player").transform;
		}
		WMoveAnimate = GetComponent <Animator> ();
	}

	void Update () {
		if (SceneManager.GetActiveScene ().name == "Main") {
			//徘徊するやつ http://blog.uzutaka.com/entry/2015/10/14/031633 より
			if (search == true) {
				WMoveAnimate.SetBool("Trolrun",true);
				speed = 5;
				//			Vector3 direction = player.transform.position - transform.position;
				//			Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
				//			transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
				Quaternion targetRotation = Quaternion.LookRotation (player.position - transform.position);
				//Debug.Log (targetRotation);
				//targetRotation = Quaternion.Euler (0,targetRotation.y,0);
				//targetRotation = Quaternion.Euler(-90,targetRotation.y,targetRotation.z);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
				//transform.LookAt(player.position);
				transform.rotation = Quaternion.Euler (0, this.transform.rotation.eulerAngles.y, 0);
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
			}
			if (search == false) {
				WMoveAnimate.SetBool("Trolrun",false);
				WMoveAnimate.SetBool("Trolwalk",true);
				speed = 2;
				float sqrDistanceToTarget = Vector3.SqrMagnitude (transform.position - targetPosition);
				if (sqrDistanceToTarget < changeTargetSqrDistance) {
					targetPosition = GetRandomPositionOnLevel ();
				}
				Quaternion targetRotation = Quaternion.LookRotation (targetPosition - transform.position);
				//targetRotation = Quaternion.Euler(-90,targetRotation.y,targetRotation.z);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
				//transform.rotation = Quaternion.Euler (-90,transform.rotation.eulerAngles.y,0);
				transform.Translate (Vector3.forward * speed * Time.deltaTime);
			}
		}
	}

	public Vector3 GetRandomPositionOnLevel(){
		//目標地点
		//float levelSize = 55f;
		return new Vector3(Random.Range(-110, 0), 0.5f, Random.Range(315, 360));
	}

	//索敵範囲に入ってきたとき
	void OnTriggerEnter (Collider other){
		if (other.CompareTag ("Player")) {
			if(StatusManager.instance.RestS == true){
				search = true;
			}
		}
	}

	void OnTriggerExit (Collider other){
		if (other.CompareTag ("Player")) {
			search = false;
		}
	}
}
