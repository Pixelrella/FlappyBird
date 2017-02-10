using UnityEngine;
using System.Collections;

public class HorizontalCollector : MonoBehaviour
{
	[SerializeField]
	private string tagName;

	protected GameObject[] objects;
	protected float lastObjectX;

	void Awake () {

		InitObjects ();
		InitLastObjectPosition ();
	}

	protected virtual void InitObjects() {
		objects = GameObject.FindGameObjectsWithTag (tagName);
	}

	private void InitLastObjectPosition () {

		lastObjectX = objects [0].transform.position.x;

		for (int i = 1; i < objects.Length; i++) {
			lastObjectX = Mathf.Max(lastObjectX, objects[i].transform.position.x);
		}
	}

	void OnTriggerEnter2D (Collider2D target) {

		if (IsRightObject (target)) {
			SetNewLastObject (target);
		}
	}

	protected bool IsRightObject (Collider2D target) {
		return target.tag == tagName;
	}

	protected void SetNewLastObject (Collider2D target) {

		Vector3 temp = target.transform.position;
		
		temp.x = lastObjectX + GetOffsetNextObject(target);
		target.transform.position = temp;
		
		UpdateLastObjectPosition (temp.x);
	}

	private void UpdateLastObjectPosition (float posX) {
		lastObjectX = posX;
	}

	protected virtual float GetOffsetNextObject (Collider2D target) {
		return ((BoxCollider2D)target).size.x;
	}
}

