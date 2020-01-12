using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TitleScene : MonoBehaviour {

	[SerializeField]
	private GameObject firstSelect;

	public void ActivateOrNotActivate(bool flag) {
		for(var i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<Button>().interactable = flag;
		}
		if (flag) {
			EventSystem.current.SetSelectedGameObject (firstSelect);
		}
	}

	public Button gstart;
	public Button htplay;
	public Button reset;

	// Use this for initialization
	void Start () {
		gstart.onClick.AddListener (movegame);
		htplay.onClick.AddListener (moveplay);
		reset.onClick.AddListener (GReset);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void movegame (){
		SceneManager.LoadScene ("Main");
	}

	public void moveplay(){
		SceneManager.LoadScene ("HTP");
	}

	public void GReset(){
		PlayerPrefs.DeleteAll ();
	}
}
