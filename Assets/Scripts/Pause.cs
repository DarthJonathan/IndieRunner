using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

	public static bool isPaused = false;
	public Texture menuBackground;
	public Texture scoreBoxBackground;
	public GUIStyle pauseBtn;
	public GUIStyle restartBtn;
	public GUIStyle gameOverStyle = new GUIStyle();
	public GUIStyle pauseStyle = new GUIStyle();
	public GUIStyle scorePauseStyle;
	public GUIStyle scoreBox;
	private Color red = new Color (0.56f, 0.23f, 0.29f);

	private AudioSource source;
	public AudioClip buttonPressed;

	void Start ()
	{
		scoreBox.normal.textColor = Color.white;
		pauseStyle.normal.textColor = red;
		scorePauseStyle.normal.textColor = red;
		gameOverStyle.normal.textColor = red;
		source = GetComponent<AudioSource> ();
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			togglePause ();
			source.PlayOneShot (buttonPressed);
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
		GUI.Box(new Rect(20,20,160,100), scoreBoxBackground, scoreBox);
		GUI.Box(new Rect(20,20,160,100), Player.playerScore.ToString("f0"), scoreBox);

//		Paus
		if (isPaused && Player.isAlive) {
			
			// Make a black background box
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height),"",pauseStyle);

//			Make a GUI Box Pause
			GUI.Box(new Rect (Screen.width / 2 - 375, Screen.height / 2 - 250, 750, 500), menuBackground, pauseStyle);
			GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 160, 250, 250), "Game is Paused", pauseStyle);

			//			Display score
			GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 10, 250, 250), "Your Score is : " + Player.playerScore.ToString("f0"), scorePauseStyle);


			// Resume Button
			if (GUI.Button (new Rect (Screen.width / 2 - 110, Screen.height / 2 + 40, 100, 100),"", pauseBtn)) {
				togglePause ();
				source.PlayOneShot (buttonPressed);
			}

			// Restart Button
			if (GUI.Button (new Rect (Screen.width / 2 + 20, Screen.height / 2 + 40, 100, 100),"", restartBtn)) {
				SceneManager.LoadScene ("GamePlay");
				source.PlayOneShot (buttonPressed);
			}

		} else if (Player.isAlive == false) {

//			Stop the game
			Time.timeScale = 0;
			// Make a background box
			GUI.Box (new Rect (0, 0, Screen.width, Screen.height), "", gameOverStyle);

			//			Make a GUI Box Pause
			GUI.Box(new Rect (Screen.width / 2 - 375, Screen.height / 2 - 250, 750, 500), menuBackground, gameOverStyle);
			GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 125, 250, 250), "Game Over", gameOverStyle);

			if (Player.playerScore > (float)highScoresScript.highScore) {
				//			High Score
				GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 40, 250, 250), "New High Score! : " +  Player.playerScore.ToString ("f0"), scorePauseStyle);

				highScoresScript.setHighScore ((int)Player.playerScore);

			} else {
				
				//			Display score
				GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 20, 250, 250), "Your Score is : " + Player.playerScore.ToString ("f0"), scorePauseStyle);

				//			High Score
				GUI.Box (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 60, 250, 250), "High Score is : " + highScoresScript.highScore.ToString(), scorePauseStyle);
			}

			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if (GUI.Button (new Rect (Screen.width / 2 - 75, Screen.height / 2 + 10, 150, 150), "", restartBtn)) {
				SceneManager.LoadScene ("GamePlay");
				source.PlayOneShot (buttonPressed);
			}
		}
	}
}
