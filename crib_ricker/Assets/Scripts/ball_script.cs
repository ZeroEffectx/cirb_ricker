using UnityEngine;
using System.Collections;

public class ball_script : MonoBehaviour {

	private GameObject master;
	private float constant_speed = 2;
	private Vector2 direction;
	private Vector2 initialPathStart;
	private Vector2 initialPathEnd;
	public bool inPlay;
	private bool selectingDirection;

	// Use this for initialization
	void Awake () {
		master = GameObject.FindGameObjectWithTag ("master");
		direction = new Vector2(0,0);
		inPlay = false;
		selectingDirection = false;
		initialPathStart = new Vector2(0,0);
	}

	void OnMouseDown() {
		if(inPlay == false) {
			selectingDirection = true;
			initialPathStart.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
			initialPathEnd.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
		}
	}

	void Update() {
		if(Input.GetMouseButtonUp(0) && selectingDirection == true) {
			initialPathEnd.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
			initialPathEnd.y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
			direction = Mathf.Atan2 (v2.y, v2.x) * Mathf.Rad2Deg
			Debug.Log("initialPathStart: " + initialPathStart.ToString ());
			Debug.Log("initialPathEnd: " + initialPathEnd.ToString());
			Debug.Log("direction" + direction.ToString ());
			selectingDirection = false;
			inPlay = true;
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		// Movement logic goes here.
		gameObject.GetComponent<Rigidbody2D>().velocity = constant_speed*direction.normalized;
	}

	void OnCollisionEnter2D (Collision2D other) {
		// Increment paddle and score, then destroy other
		if (other.gameObject.tag == "box") {
			master.gameObject.SendMessage ("add_points", 1);
			master.gameObject.SendMessage ("add_paddle", 1);
			Destroy (other.gameObject);
		}
		// destroy other
		if (other.gameObject.tag == "paddle") {
			Destroy (other.gameObject);
		}

		Vector2 u = Vector2.Dot(direction, other.contacts[0].normal) / Vector2.Dot(other.contacts[0].normal, other.contacts[0].normal)*other.contacts[0].normal;
		Vector2 w = direction - u;
		direction = w - u;
	}

	void OnTriggerEnter2D (Collider2D other) {
		// die
		if (other.gameObject.tag == "death_zone") {
			master.gameObject.SendMessage ("die", true);
			Destroy (gameObject);
		}
	}
}
