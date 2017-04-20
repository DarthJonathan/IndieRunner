using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highScoresScript : MonoBehaviour {

	public static int highScore;

	public static void setHighScore(int highscore)
	{
		if (highScore < highscore) {
			highScore = highscore;
		}
	}

}
