using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public static float offsetX;

	void Update () {
	
		if (isCameraMoving ()) {
			MoveTheCamera ();
		}
	}

	bool isCameraMoving () {
		return BirdScript.instance != null &&
			BirdScript.instance.isAlive;
	}

	void MoveTheCamera() {
		Vector3 temp = transform.position;
		temp.x = BirdScript.instance.GetPositionX () + offsetX;
		transform.position = temp;
	}


}
