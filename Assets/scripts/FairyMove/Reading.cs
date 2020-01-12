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

	string[] MajDic2 = {"＜シルフリカ＞　身体を活性化させ体力を回復する魔術　使用者の魔力量により効果が変化する",
		"＜クロッカロッカー＞　対象の周囲に発生させた鉱石によって動きを止め衝撃を与える魔術",
		"＜フェルペイズ＞　使用者の体力を魔力に変換し、元々の魔力とともに放出し衝撃を与える魔術",
		"本はここで終わっている"
	};

	string[] JemDic = {"稀に世界に満ちている魔力が結晶化して出現する鉱石がある　その鉱石はジェムと呼ばれ使われている", 
		"ジェムには身体能力を向上させる効果があり、特に魔力と体力に大きな影響が出ることが確認されている",
		"ジェムは色によって効果が変わり、青色のものは魔力に、桃色のものは体力に影響が出る", 
		"身体に及ぼす影響はジェムの形によっても変わり、基本的に大きくなるほどに影響も大きくなるとされている",
		"本はここで終わっている"};

	string[] HisBok ={"＜種族＞　この世界には人間の他に魔物、妖精などの種族が存在している。妖精は小さな体を持ち飛び回っている",
		"＜魔力＞　魔力を操ることで魔術を用いることができる　魔力が充満している地点では魔力の補充を行うことも出来る",
		"＜魔物＞　魔物を操ることのできる「マオー」という存在が存在するという伝承がこの世界に伝えられている",
		"本はここで終わっている"};

	string[] BoyNote = {"魔術使用に必要な魔力や魔術の威力のまとめ　　　　＜名前＞(必要魔力量)(推定威力)備考",
		"＜リールストー＞(3)(5)目に入ったら痛そう　　　　＜ジェイムレーン＞(5)(12)頭に当たらないようにしたいな",
		"＜グリーエグス＞(8)(21)爆風が無いのは不思議　　＜シルフリカ＞(10)(0)回復魔法はとても珍しいみたい",
		"＜クロッカロッカー＞(13)(35)時間を止めたみたい ＜フェルペイズ＞(17)(42)倒れそうなときに使うのは厳禁",
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
			if(Bookread == -1){
				talk.text = "高位魔術書";
				mwindow.SetActive (true);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (Timer <= 0) {
					if (Bookread <= 3) {
						Bookread += 1;
						talk.text = MajDic2 [Bookread];
						Timer = 1;
					}
				}
			}
		}
		if (other.gameObject.name == "history") {
			if (Bookread == -1) {
				talk.text = "伝承記録書";
				mwindow.SetActive (true);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (Timer <= 0) {
					if (Bookread <= 3) {
						Bookread += 1;
						talk.text = HisBok [Bookread];
						Timer = 1;
					}
				}
			}
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
		if (other.gameObject.name == "MajicNote") {
			if (Bookread == -1) {
				talk.text = "魔術の記録　3";
				mwindow.SetActive (true);
			}
			if (Input.GetKeyUp (KeyCode.Space)) {
				if (Timer <= 0) {
					if (Bookread <= 4) {
						Bookread += 1;
						talk.text = BoyNote [Bookread];
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
