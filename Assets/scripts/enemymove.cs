using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemymove : MonoBehaviour {

	private float speed = 3f;

	private float rotationSmooth = 1f;

	private Vector3 targetPosition;

	private float changeTargetSqrDistance = 40f;

	private Transform player;


	// Use this for initialization
	void Start () {
		targetPosition = GetRandomPositionOnLevel();
		player = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		sakuteki ();

		//徘徊するやつ http://blog.uzutaka.com/entry/2015/10/14/031633 より
		float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
		if (sqrDistanceToTarget < changeTargetSqrDistance)
		{
			targetPosition = GetRandomPositionOnLevel();
		}

		Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

		transform.Translate(Vector3.forward * speed * Time.deltaTime);

	}

	public Vector3 GetRandomPositionOnLevel(){
		//目標地点
		float levelSize = 55f;
		return new Vector3(Random.Range(-levelSize, levelSize), 0.5f, Random.Range(-levelSize, levelSize));
	}

	void sakuteki(){
		//ray飛ばしてプレイヤー探索
		int distance = 4;
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;
		Debug.DrawLine (ray.origin, ray.direction * distance, Color.red);

		if (Physics.Raycast(ray,out hit,distance))
		{
			if (hit.collider.tag == "Player"){
				Debug.Log ("hit");
				Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
				transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}
}
}