using UnityEngine;
using System.Collections;

public class master_script : MonoBehaviour {

	public int score;
	public int paddles;

	// Use this for initialization
	void Start () {
		score = 0;
		paddles = 5;
	}
	
	// Update is called once per frame
	void Update () {
		add_paddle (1);
	}

	// Add number of paddles
	void add_paddle (int addition) {
		paddles += addition;
	}

	// subtract number of paddles
	void subtract_paddle (int subtraction) {
		paddles -= subtraction;
	}

	// add score
	void add_points (int addition) {
		score += addition;
	}

	// subtract number of paddles
	void subtract_points (int subtraction) {
		score -= subtraction;
	}
}
