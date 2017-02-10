using UnityEngine;
using System.Collections;

/**
 * Extension ideas:
 *  - Let PipeCollector control if moving is active or not
 * 		- Random
 * 		- After certain time/ distance / count
 */
public class MovingPipe : MonoBehaviour {

	[SerializeField]
	private float maxValueY = 1.4f;
	[SerializeField]
	private float minValueY = -1.5f;
	[SerializeField]
	private float speed = 1.2f;

	private float direction;
	private float lastPositionX;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {

		GetNewDirection ();
		EnsureBoundaries ();

		Vector3 temp = transform.position;
		temp.y += direction * speed * Time.deltaTime;
		transform.position = temp;

	}

	private void ChooseNewDirection () {

		direction = Random.Range (-1f, 1f);
	}

	private void SwitchDirection () {
		direction *= -1;
	}

	private void EnsureBoundaries () {

		if (direction < 0) {
			if (transform.position.y < minValueY) {
				SwitchDirection();
			}
		}

		if (direction > 0) {
			if (transform.position.y > maxValueY) {
				SwitchDirection();
			}
		}
	}

	private void GetNewDirection() {
		if (transform.position.x != lastPositionX) {
			ChooseNewDirection ();
			lastPositionX = transform.position.x;
		}
	}

}
