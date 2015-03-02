using UnityEngine;
using System.Collections;

public class ball_script : MonoBehaviour {

	private GameObject master;

	// Use this for initialization
	void Awake () {
		master = GameObject.FindGameObjectWithTag ("master");
	}
	
	// Update is called once per frame
	void Update () {
		// Movement logic goes here.
	}

	void OnCollisionEnter2D (Collision2D other) {
		// Increment paddle and score, then destroy other
		if (other.gameObject.tag == "box") {
			master.gameObject.SendMessage ("add_points", 1);
			master.gameObject.SendMessage ("add_paddle", 1);
			Destroy (other.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		// Increment paddle and score, then destroy other
		if (other.gameObject.tag == "death_zone") {
			master.gameObject.SendMessage ("die", true);
			Destroy (gameObject);
		}
	}

}
