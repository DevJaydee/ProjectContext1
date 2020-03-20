using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
	#region Variables
	[SerializeField] private GameObject cloudPrefab = default;  // Prefab of the cloud
	[SerializeField] private float distanceBetweenSpawns = 5f;  // How much distance between the previous cloud before we spawn a new cloud
	[SerializeField] private List<GameObject> cloudsInScene = new List<GameObject>();   // list with all the clouds in the scene.

	[SerializeField] private float horizontalMin = -Screen.width;
	[SerializeField] private float horizontalMax = Screen.width;
	[SerializeField] private float halfHeight;
	[SerializeField] private float halfWidth;
	#endregion

	#region Getters & Setters

	#endregion

	#region Monobehaviour Callbacks
	private void Start()
	{
		Camera camera = Camera.main;

		float halfHeight = camera.orthographicSize;
		float halfWidth = camera.aspect * halfHeight;

		horizontalMin = -halfWidth;
		horizontalMax = halfWidth;
	}

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
			GameObject newCloudGO = Instantiate(cloudPrefab, transform.position, Quaternion.identity);
			cloudsInScene.Add(newCloudGO);
		}
	}
	#endregion
}
