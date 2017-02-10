using UnityEngine;
using System.Collections;

public class PipeCollector : HorizontalCollector
{
	[SerializeField]
	private float distanceBetweenPipes = 3.5f;
	[SerializeField]
	private float pipeMinY = -1.5f;
	[SerializeField]
	private float pipeMaxY = 2.4f;

	private CollectableSpawner collectableSpawner;
	private int pipesSpawned = 0;
	
	protected override void InitObjects ()
	{
		base.InitObjects ();
		RandomizeVerticalPositions ();
		InitCollectables ();
	}
	
	private void RandomizeVerticalPositions () {
		
		for (int i = 0; i < objects.Length; i++) {
			Vector3 temp = objects[i].transform.position;
			temp.y = GetRandomVerticalPosition ();
			objects[i].transform.position = temp;
		}
	}

	private float GetRandomVerticalPosition () {
		return Random.Range (pipeMinY, pipeMaxY);
	}
	
	private void InitCollectables () {

		GameObject spawner = GameObject.FindWithTag ("CollectableSpawner");
		collectableSpawner = spawner.gameObject.GetComponent<CollectableSpawner> ();
	}

	protected override float GetOffsetNextObject (Collider2D target) {

		pipesSpawned ++;

		if (SpawnCollectableTreshold ()) {
			SpawnCollectable();
			return distanceBetweenPipes*2;
		}

		return distanceBetweenPipes;
	}

	private void SpawnCollectable () {

		Vector3 position = new Vector3 ();
		position.y = GetRandomVerticalPosition ();
		position.x = lastObjectX + distanceBetweenPipes;

		collectableSpawner.SpawnCollectableAt (position);

		pipesSpawned = 0;
	}
	
	private bool SpawnCollectableTreshold () {

		int random = Random.Range (-1, 1);

		return pipesSpawned + random >= collectableSpawner.collectableTreshold;
	}



}

