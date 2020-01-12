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

	void OnTriggerStay (Collider other)
	{
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
			serif.text = "ここが出口だ";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				SceneManager.LoadScene ("Main");
			}
		}
		if (other.gameObject.tag == "First") {
			serif.text = "ストァーフの村";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("FirstTownSce");
			}
		}
		if (other.gameObject.name == "catsle") {
			serif.text = "王家の城　跡地";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("BossScene");
			}
		}
		if (other.gameObject.name == "Library") {
			serif.text = "グレースライブラリ";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("Liblarytown");
			}
		}
		if (other.gameObject.name == "Mounta") {
			serif.text = "山岳商店";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("MountainTown");
			}
		}
		if (other.gameObject.name == "SeaSide") {
			serif.text = "サイドシーング街";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("SeaSideTown");
			}
		}
		if (other.gameObject.name == "Brokent") {
			serif.text = "ラートスの村";
			Log.SetActive (true);
			if (Input.GetKey (KeyCode.Space)) {
				Log.SetActive (false);
				StatusManager.instance.playerpos = this.gameObject.transform.position;
				StatusManager.instance.playerrote = this.gameObject.transform.rotation;
				SceneManager.LoadScene ("Brokentown");
			}
		}
		if (other.gameObject.tag == "hpluss" || other.gameObject.tag == "mpluss") {
			if (other.gameObject.tag == "hpluss" && ItemDestroyMain.instance.hi1 == 1) {
				serif.text = "柔らかな力を感じる";
				Log.SetActive (true);
				if (Input.GetKey (KeyCode.Space)) {
					ItemManager.instance.ItemLoad ();
					ItemManager.instance.mhpi1 += 1;
					ItemManager.instance.ItemGet ();
					Destroy (other.gameObject);
					Log.SetActive (false);
					if (other.gameObject.name == "HPitem1") {
						ItemDestroyMain.instance.hi1 = 0;
						ItemDestroyMain.instance.Loaditemprefs ();
					}
				}
			}
			if (other.gameObject.tag == "mpluss" && ItemDestroyMain.instance.mi1 == 1) {
				serif.text = "柔らかな力を感じる";
				Log.SetActive (true);
				if (Input.GetKey (KeyCode.Space)) {
					ItemManager.instance.ItemLoad ();
					ItemManager.instance.mmpi1 += 1;
					ItemManager.instance.ItemGet ();
					Destroy (other.gameObject);
					Log.SetActive (false);
					if (other.gameObject.name == "MPitem1") {
						ItemDestroyMain.instance.mi1 = 0;
						ItemDestroyMain.instance.Loaditemprefs ();
					}
				}
			}
		}
		if (other.gameObject.tag == "hplusm" || other.gameObject.tag == "mplusm") {
			if (other.gameObject.tag == "hplusm") {
				if (other.gameObject.name == "HPitem2" && ItemDestroyMain.instance.hi2 == 1) {
					serif.text = "暖かな力を感じる";
					Log.SetActive (true);
					if (Input.GetKey (KeyCode.Space)) {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mhpi2 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						ItemDestroyMain.instance.hi2 = 0;
						ItemDestroyMain.instance.Loaditemprefs ();
					}
				}
			}
		}
		if (other.gameObject.tag == "hplusl" || other.gameObject.tag == "mplusl") {
			if (other.gameObject.tag == "hplusl" && ItemDestroyMain.instance.hi3 == 1){
				serif.text = "心地のいい力を感じる";
				Log.SetActive (true);
				if (Input.GetKey (KeyCode.Space)) {
					ItemManager.instance.ItemLoad ();
					ItemManager.instance.mhpi3 += 1;
					ItemManager.instance.ItemGet ();
					Destroy (other.gameObject);
					Log.SetActive (false);
					if (other.gameObject.name == "HPitem3") {
						ItemDestroyMain.instance.hi3 = 0;
						ItemDestroyMain.instance.Loaditemprefs ();
					}
				}
			}
			if (other.gameObject.tag == "mplusl") {
				if (other.gameObject.name == "MPitem3" && ItemDestroyMain.instance.mi3 == 1) {
					serif.text = "心地のいい力を感じる";
					Log.SetActive (true);
					if (Input.GetKey (KeyCode.Space)) {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mmpi3 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						Log.SetActive (false);
						ItemDestroyMain.instance.mi3 = 0;
						ItemDestroyMain.instance.Loaditemprefs ();
					}
				}
				if (other.gameObject.tag == "mplusl") {
					if (other.gameObject.name == "2MPitem3" && ItemDestroyMain.instance.mi6 == 1) {
						serif.text = "心地のいい力を感じる";
						Log.SetActive (true);
						if (Input.GetKey (KeyCode.Space)) {
							ItemManager.instance.ItemLoad ();
							ItemManager.instance.mmpi3 += 1;
							ItemManager.instance.ItemGet ();
							Destroy (other.gameObject);
							Log.SetActive (false);
							ItemDestroyMain.instance.mi6 = 0;
							ItemDestroyMain.instance.Loaditemprefs ();
						}
					}
				}
			}
			if (other.gameObject.tag == "hplusg" || other.gameObject.tag == "mplusg") {
				if (other.gameObject.tag == "hplusg" && ItemDestroyMain.instance.hi4 == 1) {
					serif.text = "途方も無い力を感じる";
					Log.SetActive (true);
					if (Input.GetKey (KeyCode.Space)) {
						ItemManager.instance.ItemLoad ();
						ItemManager.instance.mhpi4 += 1;
						ItemManager.instance.ItemGet ();
						Destroy (other.gameObject);
						if (other.gameObject.name == "HPitem4") {
							ItemDestroyMain.instance.hi4 = 0;
							ItemDestroyMain.instance.Loaditemprefs ();
						}
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

	void OnCollisionExit(Collision other){
		Log.SetActive (false);
	}
}
