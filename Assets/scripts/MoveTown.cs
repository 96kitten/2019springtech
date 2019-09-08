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
			if (Input.GetKey (KeyCode.Space)) {
				StatusManager.instance.RestS = false;
				fiarymove.moving = false;
				StatusManager.instance.LoadMaxStatus ();
				StatusManager.instance.hprecovery ();
				mover.SetBool ("is_Resting", true);
				rcount = 1;
				StartCoroutine ("Animate");
			}
		}
		if (other.gameObject.tag == "backtotown") {
			serif.text = "ここが村の出口だ";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				SceneManager.LoadScene ("Main");
			}
		}
		if (other.gameObject.tag == "First") {
			serif.text = "ストァーフの村 緑が多くてのどやかな場所";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("FirstTownSce");
			}
		}
		if (other.gameObject.tag == "hpluss" || other.gameObject.tag == "mpluss") {

				serif.text = "柔らかな力を感じる";
				Log.SetActive (true);
				if (Input.GetKey (KeyCode.Space)) {
					if (other.gameObject.tag == "hpluss") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mhpi1 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						if (other.gameObject.name == "HPitem1") {
							ItemDestroyMain.instance.hi1 = false;
						}
					}
					if (other.gameObject.tag == "mpluss") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mmpi1 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						if (other.gameObject.name == "MPitem1") {
							ItemDestroyMain.instance.mi1 = false;
						}
					}
				}
		}
		if (other.gameObject.tag == "hplusm" || other.gameObject.tag == "mplusm") {
				serif.text = "暖かな力を感じる";
				Log.SetActive (true);
				if (Input.GetKey (KeyCode.Space)) {
					if (other.gameObject.tag == "hplusm") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mhpi2 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						if (other.gameObject.name == "HPitem2") {
							ItemDestroyMain.instance.hi2 = false;
						}
						if (other.gameObject.name == "3HPitem2") {
							ItemDestroyMain.instance.hi5 = false;
						}
					}
					if (other.gameObject.tag == "mplusm") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mmpi2 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						if (other.gameObject.name == "MPitem2") {
							ItemDestroyMain.instance.mi2 = false;
					}
				}
			}
		}
		if (other.gameObject.tag == "hplusl" || other.gameObject.tag == "mplusl") {
				serif.text = "心地のいい力を感じる";
				Log.SetActive (true);
				if (Input.GetKey (KeyCode.Space)) {
					if (other.gameObject.tag == "hplusl") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mhpi3 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						if (other.gameObject.name == "HPitem3") {
							ItemDestroyMain.instance.hi3 = false;
						}
					}
					if (other.gameObject.tag == "mplusl") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mmpi3 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						if (other.gameObject.name == "HPitem3") {
							ItemDestroyMain.instance.mi3 = false;
						}
						if (other.gameObject.name == "2MPitem3") {
							ItemDestroyMain.instance.mi6 = false;
						}
						if (other.gameObject.name == "3MPitem2") {
							ItemDestroyMain.instance.mi7 = false;
						}
					}
				}
			}
		if (other.gameObject.tag == "hplusg" || other.gameObject.tag == "mplusg") {
				serif.text = "途方も無い力を感じる";
				Log.SetActive (true);
				if (Input.GetKey (KeyCode.Space)) {
					if (other.gameObject.tag == "hplusg") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mhpi4 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						if (other.gameObject.name == "HPitem4") {
							ItemDestroyMain.instance.hi4 = false;
						}
					}
					if (other.gameObject.tag == "mplusg") {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mmpi4 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						if (other.gameObject.name == "MPitem4") {
							ItemDestroyMain.instance.mi4 = false;
						}
						if (other.gameObject.name == "2MPitem4") {
							ItemDestroyMain.instance.mi5 = false;
						}
					}
				}
			}
	}

	private IEnumerator Animate(){
		yield return new WaitForSeconds (2.0f); 
		serif.text = "体力が回復した" ;
		mover.SetBool ("is_Resting",false);
		fiarymove.moving = true;
		StatusManager.instance.RestS = true;
	}

	void OnTriggerExit(Collider other){
		Log.SetActive (false);
		rcount = 0;

	}
}
