using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reading : MonoBehaviour {
	
	public Text talk;
	public GameObject mwindow;

	int Bookread = 0;
	public float Timer = 0;

	string[] EneDic = {"灰狼＜かいろう＞　見た目は通常の狼達と変わらないが、魔力により凶暴性が増している。",
		"石像兵＜せきぞうへい＞　元はただの石像だったが、長年魔力に触れ合ったことにより動き出すようになった。",
	"本はここで終わっている"};

	string[] EneDic2 = {"小鬼＜こおに＞　小さな体を持ち、敵を発見すると素早く追いかけてくる　武器を持つ個体も存在する。",
		"魔物は魔力によって生み出されており、いくら倒してもすぐに新たな個体が生まれる。出会った場合逃走が賢明だろう。",
		"本はここで終わっている"};
	// Use this for initialization

	void Start () {
		mwindow.SetActive (false);
		Bookread = -1;
	}
	
	// Update is called once per frame
	void Update () {
		Timer -= Time.deltaTime;
		if(Timer <= 0){
			Timer = 0;
		}
	}

	void OnTriggerStay(Collider other){
		if (other.gameObject.name == "enedic") {
			if (Bookread == -1) {
				talk.text = "世界の魔物たち";
				mwindow.SetActive (true);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (Timer <= 0) {
					if (Bookread <= 2) {
						Debug.Log (Bookread);
						Bookread += 1;
						talk.text = EneDic [Bookread];
						Timer = 1;
					}
				}
			}
		}
		if (other.gameObject.name == "enedic2") {
			if (Bookread == -1) {
				talk.text = "世界の魔物たち　二巻";
				mwindow.SetActive (true);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (Timer <= 0) {
					if (Bookread <= 2) {
						Bookread += 1;
						talk.text = EneDic2 [Bookread];
						Timer = 1;
					}
				}
			}
		}
		if (other.gameObject.name == "majickdic") {
			talk.text = "魔術書";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "majickdic2") {
			talk.text = "高位魔術書";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "history") {
			talk.text = "伝承記録書";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "history2") {
			talk.text = "鉱石について";
			mwindow.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other){
		mwindow.SetActive (false);
		Bookread = -1;
	}
}
