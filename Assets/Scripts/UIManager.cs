using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	AudioSource source;
	public AudioClip bgm;
	public AudioClip traffic;

	void Start()
	{
		source = GetComponent<AudioSource> ();
		source.PlayOneShot (bgm);
		source.PlayOneShot (traffic);
	}

	void update()
	{
		if (source.time == traffic.length) {
			source.PlayOneShot (bgm);
			source.PlayOneShot (traffic);
		}
	}

	public void StartGame ()
	{
		SceneManager.LoadScene ("GamePlay");

	}

	public void ExitGame()
	{
		return;
	}
}
