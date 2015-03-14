using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class master_script : MonoBehaviour {

	public Text score_text;
	public Text paddles_text;

	public GameObject paddle;
	private GameObject paddle_temp;
	public GameObject ball;

	public int score;
	public int paddles;
	private int status;

	private Vector2 mouse_down;
	private Vector2 mouse_pos;
	private float angle;
	private Vector2 v2;
	private float current_size;

	private bool paused;

	public GameObject win_menu;
	public GameObject lose_menu;

	void Awake () {
		//issues with restarting from pause, win, and lose menus
		Time.timeScale = 1.0f;

		ball=GameObject.FindGameObjectWithTag ("ball");
	}

	// Use this for initialization
	void Start () {
		score = 0;
		paddles = 5;
		update_paddle_text ();
		update_score_text ();
	}

	void Update () {
		if(ball.GetComponent<ball_script>().inPlay == true) {
			if (Input.GetMouseButtonDown (0)) {
				// get position of the mouse on click
				if (paddles > 0) {
					mouse_down = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					paddle_temp = Instantiate (paddle, mouse_down, Quaternion.identity) as GameObject;
				}
			}
			if (Input.GetMouseButton (0)) {
				if (paddles > 0) {
					// get position of the mouse
					mouse_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
					// calculate the angle between down press, and mouse position
					//	then convert that to degree (-180 to 180)
					v2 = mouse_pos - mouse_down;
					angle = Mathf.Atan2 (v2.y, v2.x) * Mathf.Rad2Deg;
					// update the rotation of the current paddle being placed to angle value.
					if (gameObject != null) {
						paddle_temp.transform.eulerAngles = new Vector3 (0, 0, angle);
					}

					current_size = Mathf.Sqrt((mouse_pos.x - mouse_down.x)*(mouse_pos.x - mouse_down.x) + (mouse_pos.y - mouse_down.y)*(mouse_pos.y - mouse_down.y));
					if (current_size < 1) {
						paddle_temp.transform.localScale = new Vector3(current_size, 1, 1);
					}
					else {
						paddle_temp.transform.localScale = new Vector3(1,1,1);
					}
				}
			}
			if (Input.GetMouseButtonUp (0)) {
				if (paddles > 0) {
					paddle_temp.transform.localScale = new Vector3(1,1,1);
					// remove a paddle, because we placed one
					subtract_paddle (1);
				}
			}
		}
	}

	public void check_pause (GameObject pause_menu) {
		if (paused) {
			unpause (pause_menu);
		} else {
			pause (pause_menu);
		}
	}

	// pause time, maybe add pause sound?
	void pause (GameObject pause_menu) {
		// check and set timescale accordingly
		paused = true;
		Time.timeScale = 0.0f;
		pause_menu.SetActive (true);
	}

	void unpause (GameObject pause_menu) {
		// check and set timescale accordingly
		paused = false;
		Time.timeScale = 1.0f;
		pause_menu.SetActive (false);
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
			lose ();
		}
	}

	// win
	void win () {
		// set timescale to 0
		Time.timeScale = 0.0f;
		win_menu.SetActive (true);
	}

	// lose
	void lose () {
		// set timescale to 0
		Time.timeScale = 0.0f;
		lose_menu.SetActive (true);
	}

}
