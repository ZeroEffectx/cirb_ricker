using UnityEngine;
using System.Collections;

public class nav_script : MonoBehaviour {
	
	// load the scene passed
	public void load_level (string scene) {
		Application.LoadLevel(scene);
	}
	// reload this scene
	public void reload_level () {
		Application.LoadLevel (Application.loadedLevelName);
	}

	// info menu
	public void show_info (GameObject info_menu) {
		if (info_menu.activeSelf) {
			info_menu.SetActive (false);
		} else {
			info_menu.SetActive (true);
		}
		
	}

}
