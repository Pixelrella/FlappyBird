using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

	public static GameplayController instance;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private GameObject gameoverPanel;

	[SerializeField]
	private GameObject readyButton;

			
	void Awake () {
		MakeInstance ();
	}
	
	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		Time.timeScale = 0f;

	}

	public void StartTheGame () {
		Time.timeScale = 1f;
		readyButton.SetActive (false);
	}
	
	public void SetScore (int score) {
		UpdateScoreText (scoreText, score);
	}
	
	private void UpdateScoreText (Text text, int score) {
		text.text = score.ToString ();
	}
	
	public void GameoverShowPanel () {
		gameoverPanel.SetActive (true);
	}
	
	public void RestartTheGame () {
		Application.LoadLevel ("Gameplay");
	}
}
