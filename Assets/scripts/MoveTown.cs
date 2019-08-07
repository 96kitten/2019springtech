using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveTown : MonoBehaviour {

	public GameObject Log;
	public Text serif;
	int rcount = 0;
	private Animator mover;
	public FiaryMove fiarymove;

	// Use this for initialization
	void Start () {
		mover = GetComponent<Animator> ();;
		Log.SetActive (false);
		rcount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "WorldEnd"){
			serif.text = "ここから先は未知の世界だ";
			Log.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "recover") {
			if (rcount == 0) {
				serif.text = "ここなら休めそうだ";
				Log.SetActive (true);
			}
			if(Input.GetKey(KeyCode.Space)){
				fiarymove.moving = false;
			StatusManager.instance.LoadMaxStatus ();
			StatusManager.instance.hprecovery ();
				mover.SetBool ("is_Resting",true);
				rcount = 1;
				StartCoroutine ("Animate");
			}
		}
		if(other.gameObject.tag == "First"){
			serif.text = "ストァーフの村 緑が多くてのどやかな場所" ;
			if(Input.GetKey(KeyCode.Space)){
				Debug.Log ("space");
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene("FirstTownSce");
			}
			Log.SetActive (true);
		}
	}

	private IEnumerator Animate(){
		yield return new WaitForSeconds (2.0f); 
		serif.text = "体力が回復した" ;
		mover.SetBool ("is_Resting",false);
		fiarymove.moving = true;
	}

	void OnTriggerExit(Collider other){
		Log.SetActive (false);
		rcount = 0;

	}
}
