﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class PlayerplefsDe {

	[MenuItem("Tools/Reset PlayerPrefs")]
	public static void ResetPlayerPrefs(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.Save ();

}
}