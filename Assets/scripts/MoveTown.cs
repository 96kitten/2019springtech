using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveTown : MonoBehaviour {

	public GameObject Log;
	public Text serif;

	// Use this for initialization
	void Start () {
		Log.SetActive (false);
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

	void OnTriggerExit(Collider other){
		Log.SetActive (false);
	}
}
