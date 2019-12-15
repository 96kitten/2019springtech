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

	string[] MajDic = {"＜リールストー＞　少しの間砂嵐のように小さな物体を相手にぶつける魔術",
		"＜ジェイムレーン＞　魔力を固め実体化させたものを相手に降り注がせる魔術",
		"＜グリーエグス＞　過度の魔力を一気に放出させることで爆破のような現象を引き起こす魔術",
		"本はここで終わっている"};

	string[] JemDic = {"稀に世界に満ちている魔力が結晶化して出現する鉱石がある　その鉱石はジェムと呼ばれ使われている", 
		"ジェムには身体能力を向上させる効果があり、特に魔力と体力に大きな影響が出ることが確認されている",
		"ジェムは色によって効果が変わり、青色のものは魔力に、桃色のものは体力に影響が出る", 
		"身体に及ぼす影響はジェムの形によっても変わり、基本的に大きくなるほどに影響も大きくなるとされている",
		"本はここで終わっている"};

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
			if (Bookread == -1) {
			talk.text = "魔術書";
			mwindow.SetActive (true);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (Timer <= 0) {
					if (Bookread <= 3) {
						Bookread += 1;
						talk.text = MajDic [Bookread];
						Timer = 1;
					}
				}
			}
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
			if (Bookread == -1) {
				talk.text = "鉱石について";
				mwindow.SetActive (true);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (Timer <= 0) {
					if (Bookread <= 4) {
						Bookread += 1;
						talk.text = JemDic [Bookread];
						Timer = 1;
					}
				}
			}
		}
	}

	void OnTriggerExit(Collider other){
		mwindow.SetActive (false);
		Bookread = -1;
	}
}
