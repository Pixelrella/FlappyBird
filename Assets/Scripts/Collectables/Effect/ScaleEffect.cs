using UnityEngine;
using System.Collections;

public class ScaleEffect : CollectableEffect
{
	[SerializeField]
	private float scale = .5f;


	protected override void ApplyEffect (GameObject target) {
		target.transform.localScale = new Vector3 (scale, scale, 1);
	}

}

