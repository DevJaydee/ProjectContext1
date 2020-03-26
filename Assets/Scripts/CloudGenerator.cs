using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	#region Variables
	[SerializeField] private GameObject cloudPrefab = default;  // Prefab of the cloud
	[SerializeField] private float distanceBetweenSpawns = 5f;  // How much distance between the previous cloud before we spawn a new cloud
	[SerializeField] private List<GameObject> cloudsInScene = new List<GameObject>();   // list with all the clouds in the scene.
	#endregion

	#region Getters & Setters

	#endregion

	#region Monobehaviour Callbacks
	private void Update()
	{
		SpawnCloud();
	}
	#endregion

	#region Private Voids
	private void SpawnCloud()
	{
		if(transform.position.y > cloudsInScene[cloudsInScene.Count - 1].transform.position.y + distanceBetweenSpawns)
		{
			Vector3 bottomLeftWorld = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
			Vector3 topRightWorld = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

			GameObject newCloudGO = Instantiate(cloudPrefab, new Vector3(Random.Range(bottomLeftWorld.x, topRightWorld.x), cloudsInScene[cloudsInScene.Count - 1].transform.position.y + distanceBetweenSpawns, 0), Quaternion.identity);
			cloudsInScene.Add(newCloudGO);
		}
	}
	#endregion
}
