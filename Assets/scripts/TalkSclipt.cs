using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkSclipt : MonoBehaviour {

	public Text talk;
	public GameObject mwindow;

	void Start () {
		mwindow.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Townp") {
			if (other.gameObject.name == "TownLady") {
				if(GameManager.instance.FtownL == false){
				talk.text = "こんにちは、貴女マオーを倒しに行くの？じゃあ、これあげるわ。";
				mwindow.SetActive (true);
					ItemManager.instance.mhpi2 += 1;
				GameManager.instance.FtownL = true;
				}
				if (GameManager.instance.FtownL == true) {
					talk.text = "頑張ってね！";
					mwindow.SetActive (true);
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		mwindow.SetActive (false);
	}
}
