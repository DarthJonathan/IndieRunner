using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	private bool isPaused = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			togglePause ();
		}
		
	}

	void togglePause()
	{
		if (isPaused == true) {
			Time.timeScale = 1f;
			isPaused = false;
		} else {
			Time.timeScale = 0;
			isPaused = true;
		}
	}

	void OnGUI ()
	{
//		Score
		GUI.Box(new Rect(20,20,80,50), Player.playerScore.ToString("f0"));

//		Paus
		if (isPaused && Player.isAlive) {
			
			// Make a background box
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "");

//			Make a GUI Box Pause
			GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 125, 250, 250), "Game Is Paused");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if (GUI.Button (new Rect (Screen.width / 2 - 40, Screen.height / 2 - 50, 80, 20), "Resume")) {
				togglePause ();
			}
		} else if (Player.isAlive == false) {

//			Stop the game
			Time.timeScale = 0;
			// Make a background box
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "");

			//			Make a GUI Box Pause
			GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 125, 250, 250), "Game Over");

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if (GUI.Button (new Rect (Screen.width / 2 - 60, Screen.height / 2 - 50, 120, 20), "Restart Game")) {
				SceneManager.LoadScene ("GamePlay");
			}
		}
	}
}
