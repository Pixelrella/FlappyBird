using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour 
{

	public void DestroyCollectable () {

		CancelInvoke("DestroyCollectable");
		gameObject.SetActive (false);
		
	}
	
	void OnEnable () {
		Invoke ("DestroyCollectable", 5f);
	}
}
