using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class master_script : MonoBehaviour {

	public Text score_text;
	public Text paddles_text;
	public int score;
	public int paddles;
	private int status;

	// Use this for initialization
	void Start () {
		score = 0;
		paddles = 5;
		update_paddle_text ();
		update_score_text ();
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
