using UnityEngine;
using System.Collections;

public class DayNightChange : MonoBehaviour {

	[SerializeField]
	private float speed = 1.1f;
	[SerializeField]
	private float offset = 2.0f;
	[SerializeField]
	private bool isDay = true;
	[SerializeField]
	private Color nightColor = new Color (.25f,.2f,.2f);
	[SerializeField]
	private Color dayColor = new Color (1f,1f,1f);

	private SpriteRenderer sprite;

	void Awake () {
		sprite = gameObject.GetComponent<SpriteRenderer> ();

		if (!isDay) {
			sprite.color = nightColor;
		}
	}
	
	void Update () {

		if (Time.time < offset) {
			return;
		}

		sprite.color = Color.LerpUnclamped(sprite.color, 
		                                   GetDestinationColor (), 
		                                   speed * Time.deltaTime);

		CheckForDayNightSwitch ();
	}

	private void CheckForDayNightSwitch () {

		if (ReachedDestinationColor ()) {
			isDay = !isDay;
		}
	}

	private bool ReachedDestinationColor () {

		Vector4 diff = (Vector4)(GetDestinationColor () - sprite.color);
		return diff.magnitude < 0.01f;
	}

	private Color GetDestinationColor () {

		if (isDay) {
			return nightColor;
		}

		return dayColor;
	}

}
