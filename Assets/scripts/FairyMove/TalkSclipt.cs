using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkSclipt : MonoBehaviour {

	public Text talk;
	public GameObject mwindow;

	//public RemenberPart remenbermaj;

	//GameObject PartRe;
	//RemenberPart script;

	void Start () {
		mwindow.SetActive (false);

		//PartRe = GameObject.Find ("Lady Fairy");
		//script = PartRe.GetComponent<RemenberPart>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Townp") {
			if (other.gameObject.name == "TownLady") {
				GameManager.instance.FiTownL ();
				if(GameManager.instance.FtownL == 0){
					talk.text = "こんにちは、ねえ貴女このジェムを貰ってくれない？　　スペースキーでもらう";
				mwindow.SetActive (true);
					if(Input.GetKey (KeyCode.Space)){
					ItemManager.instance.mhpi2 += 1;
				    GameManager.instance.FtownL = 1;
					GameManager.instance.FiTown ();
					}
				}
				if (GameManager.instance.FtownL == 1) {
					talk.text = "ありがとう！何かの役に立ててね。";
					mwindow.SetActive (true);
				}
			}
		}

		if (other.gameObject.name == "WiseLady1") {
			if(StatusManager.instance.ReMaj4 == 0){
				talk.text = "ねえ、貴女に特別な魔術を教えてあげるわ！";
				mwindow.SetActive (true);
				if(Input.GetKey (KeyCode.Space)){
					//script.PartPlay ();
					StatusManager.instance.ReMaj4 = 1;
					StatusManager.instance.SaveUsemajic ();
				}
			}
			if (StatusManager.instance.ReMaj4 == 1) {
				talk.text = "うまく使えると良いわね！";
				mwindow.SetActive (true);
			}
		}

		if (other.gameObject.name == "WiseLady2") {
			if(StatusManager.instance.ReMaj5 == 0){
				talk.text = "ねえ、貴女に特別な魔術を教えてあげるわ！";
				mwindow.SetActive (true);
				if(Input.GetKey (KeyCode.Space)){
					//script.PartPlay ();
					StatusManager.instance.ReMaj5 = 1;
					StatusManager.instance.SaveUsemajic ();
				}
			}
			if (StatusManager.instance.ReMaj5 == 1) {
				talk.text = "うまく使えると良いわね！";
				mwindow.SetActive (true);
			}
		}

		if (other.gameObject.name == "WiseLady3") {
			if(StatusManager.instance.ReMaj6 == 0){
				talk.text = "ねえ、貴女に特別な魔術を教えてあげるわ！";
				mwindow.SetActive (true);
				if(Input.GetKey (KeyCode.Space)){
					//script.PartPlay ();
					StatusManager.instance.ReMaj6 = 1;
					StatusManager.instance.SaveUsemajic ();
				}
			}
			if (StatusManager.instance.ReMaj6 == 1) {
				talk.text = "うまく使えると良いわね！";
				mwindow.SetActive (true);
			}
		}

		//いろんな会話
		if (other.gameObject.name == "FTownLady") {
			if(GameManager.instance.bosscount == 1){
			talk.text = "マオーが現れてからなんだか魔物が増えたらしいの。この村には影響はないみたいだけど";
			mwindow.SetActive (true);
			}
			if(GameManager.instance.bosscount == 0){
				talk.text = "マオーが倒れたんですってね。この村に何もなくてよかったわ！";
				mwindow.SetActive (true);
			}
		}
		if (other.gameObject.name == "FTownLady2") {
			talk.text = "どこかの村には強い魔術を教えてくれる妖精がいるんだってね。私も教えてもらいたいなあ";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "MTownLady") {
			talk.text = "確か、小さいジェムでも数が多くなれば魔術の威力は上がるんだったよね";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "MTownLady2") {
			talk.text = "大きいジェムばっかり付けてても、打たれ弱くなっちゃうなら考えものだよねえ";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "STownLady") {
			talk.text = "ここは魔物が来なくて平和だよね、まあ住んでる子も少ないんだけど";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "STownLady2") {
			talk.text = "わっわー！隠れてたのに見つかっちゃった！お姉ちゃんすごいね！";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "LFairy") {
			talk.text = "椅子の上……？ああ、そう僕がまとめたノートです。魔術を使用するのに必要な魔力量などをまとめたんです。読んでくださっても構いませんよ";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "BTownLady") {
			talk.text = "隣の家、前に魔物に襲われちゃってね……　この家もちょっとだけ壊れちゃったの";
			mwindow.SetActive (true);
		}
		if (other.gameObject.name == "BTownLady2") {
			if (GameManager.instance.bosscount == 1) {
				talk.text = "あーあ、誰かマオーのこと倒してくれないかなあ……";
				mwindow.SetActive (true);
			}
			if (GameManager.instance.bosscount == 0) {
				talk.text = "ねえ、君がマオーを倒したんだろ！すごいなあ、ありがとうね！";
				mwindow.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider other){
		mwindow.SetActive (false);
	}
}
