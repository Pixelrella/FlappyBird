using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectableSpawner : MonoBehaviour {

	
	public int collectableTreshold = 7;
	
	[SerializeField]
	private GameObject[] collectables;
	private List<GameObject> nextCollectables;

	void Awake () {
		
		HideCollectables ();
		nextCollectables = new List<GameObject> ();
		InitNextCollectables ();
	}

	private void HideCollectables () {
		for (int i = 0; i < collectables.Length; i++) {
			collectables[i].SetActive(false);
		}
	}

	private void InitNextCollectables () {

		nextCollectables.Clear ();

		for (int i = 0; i < collectables.Length; i++) {
			if (collectables [i].gameObject.activeInHierarchy) {
				continue;
			}

			nextCollectables.Add (collectables[i]);
		}

		Shuffle (nextCollectables);
	}

	public void SpawnCollectableAt (Vector3 position) {
		
		GameObject nextCollectable = GetNextCollectable ();
		nextCollectable.transform.position = position;
		nextCollectable.SetActive (true);
		
		InitNextCollectables ();
	}
	
	private GameObject GetNextCollectable () {

		int randomIndex = Random.Range (0, nextCollectables.Count-1);
		return nextCollectables [randomIndex];
	}

	private void Shuffle (List<GameObject> arrayToShuffle) {
		for (int i = 0; i < arrayToShuffle.Count; i++) {
			
			int randomIndex = Random.Range (i, arrayToShuffle.Count);
			this.SwitchElements (arrayToShuffle, i, randomIndex);
		}
	}
	
	private void SwitchElements (List<GameObject> arr, int i, int j) {
		
		GameObject temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}
}
