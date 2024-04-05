using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour {

	public string menuSceneName = "MainMenu";

	public SceneFader sceneFader;
	public TMP_Text roundText;

	private void Start()
	{
		roundText.text = PlayerStats.Rounds.ToString();
	}

	public void Retry ()
	{
		sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

	public void Menu ()
	{
		sceneFader.FadeTo(menuSceneName);
	}

}
