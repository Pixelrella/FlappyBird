using UnityEngine;
using System.Collections;

public class CollectableAnimation : MonoBehaviour
{
	private Vector3 animationMinScale = new Vector3(0.7f, .7f, 1.0f);
	private Vector3 animationMaxScale = new Vector3(1.2f, 1.2f, 1.0f);
	
	private bool isSmall;
	private float speed = 10.0f;

	void Update () {
		
		gameObject.transform.localScale = Vector3.LerpUnclamped (gameObject.transform.localScale,
		                                                         GetDestinationScale (),
		                                                         speed * Time.deltaTime);
		
		CheckForAnimationSwitch ();
	}
	
	private void CheckForAnimationSwitch () {
		
		if (ReachedDestination ()) {
			isSmall = !isSmall;
		}
	}
	
	private bool ReachedDestination () {
		
		Vector3 diff = GetDestinationScale () - gameObject.transform.localScale;
		return diff.magnitude < 0.01f;
	}
	
	private Vector3 GetDestinationScale () {
		
		if (isSmall) {
			return animationMaxScale;
		}
		
		return animationMinScale;
	}
}

