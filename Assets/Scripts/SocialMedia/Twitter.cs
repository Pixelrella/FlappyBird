using UnityEngine;
using System.Collections;

public class Twitter : MonoBehaviour {
	
	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en"; 

	public void ShareHighscoreToTwitter () {

		ShareToTwitter ("I scored " + BirdScript.instance.score +  " on awesome flappy bird clone! Check it out.");

	}

	void ShareToTwitter (string textToDisplay)
	{
		Application.OpenURL(TWITTER_ADDRESS +
		                    "?text=" + WWW.EscapeURL(textToDisplay) +
		                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
	}
}
