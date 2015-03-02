using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class master_script : MonoBehaviour {

	public Text score_text;
	public Text paddles_text;

	public GameObject paddle;

	public int score;
	public int paddles;
	private int status;

	private Vector2 mouse_down;
	private Vector2 mouse_up;
	private float angle;

	// Use this for initialization
	void Start () {
		score = 0;
		paddles = 5;
		update_paddle_text ();
		update_score_text ();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			// get position of the mouse on click
			mouse_down = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log ("mouse_down" + mouse_down);
		}
		if (Input.GetMouseButtonUp(0)) {
			if (paddles > 0 ) {
				// get position of the mouse on release
				mouse_up = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Debug.Log ("mouse_up" + mouse_up);
				// calculate the angle between down press, and release
				//	(this is not working as I expected)
				angle = Vector2.Angle(mouse_down,mouse_up);
				Debug.Log ("angle: " + angle);
				// remove a paddle, because we placed one
				subtract_paddle (1);
				// instantiate the paddle
				Instantiate (paddle,mouse_up,Quaternion.identity);
			}
		}
	}
	
	// Add number of paddles
	void add_paddle (int addition) {
		paddles += addition;
		update_paddle_text ();
	}

	// Subtract number of paddles
	void subtract_paddle (int subtraction) {
		paddles -= subtraction;
		update_paddle_text ();
	}

	// Add score
	void add_points (int addition) {
		score += addition;
		update_score_text ();
	}

	// Subtract score
	void subtract_points (int subtraction) {
		score -= subtraction;
		update_score_text ();
	}
	
	// Updates the paddles Text UI element
	void update_paddle_text () {
		paddles_text.text = "Paddles: " + paddles;
	}

	// Updates the score Text UI element
	void update_score_text () {
		score_text.text = "Score: " + score;
	}

	// Game Over
	void die (bool dead) {
		if (dead == true) {
			Debug.Log("Game_Over");
		}
	}

}
