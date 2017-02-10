using UnityEngine;
using System.Collections;

abstract public class CollectableEffect : MonoBehaviour {

	private CollectableScript collactableScript;

	void Awake () {
		collactableScript = gameObject.GetComponent<CollectableScript> ();
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (!IsPlayer (target.gameObject)) {
			return;
		}
		
		ApplyEffect (target.gameObject);
		collactableScript.DestroyCollectable ();
	} 

	bool IsPlayer(GameObject target) {
		return target.tag == "Player";
	}

	protected abstract void ApplyEffect (GameObject target);
}
