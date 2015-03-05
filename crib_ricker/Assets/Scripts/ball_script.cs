using UnityEngine;
using System.Collections;

public class ball_script : MonoBehaviour {

	private GameObject master;
	private float constant_speed = 1;

	// Use this for initialization
	void Awake () {
		master = GameObject.FindGameObjectWithTag ("master");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Movement logic goes here.
		GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0, constant_speed));
//		GetComponent<Rigidbody2D>().velocity = constant_speed * (GetComponent<Rigidbody2D>().velocity.normalized);
	}

	void OnCollisionEnter2D (Collision2D other) {
		// Increment paddle and score, then destroy other
		if (other.gameObject.tag == "box") {
			master.gameObject.SendMessage ("add_points", 1);
			master.gameObject.SendMessage ("add_paddle", 1);
			Destroy (other.gameObject);
		}
		// decrement paddle, then destroy other
		if (other.gameObject.tag == "paddle") {
			Destroy (other.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		// die
		if (other.gameObject.tag == "death_zone") {
			master.gameObject.SendMessage ("die", true);
			Destroy (gameObject);
		}
	}
}
