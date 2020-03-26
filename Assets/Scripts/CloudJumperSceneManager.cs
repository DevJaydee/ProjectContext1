using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudJumperSceneManager : MonoBehaviour
{
	#region Variables
	private static CloudJumperSceneManager instance = null;

	[SerializeField] private GameObject cloudJumperCharacter = default;     // Reference to the Cloud Jumper Character.
	[SerializeField] private GameObject camGo = default;
	[SerializeField] private GameObject characterGo = default;
	[SerializeField] private GameObject cloudSpawnerGo = default;
	[SerializeField] private GameObject overlayGo = default;
	#endregion

	#region Getters & Setters
	public static CloudJumperSceneManager Instance { get => instance; set => instance = value; }
	public GameObject CloudJumperCharacter { get => cloudJumperCharacter; set => cloudJumperCharacter = value; }
	#endregion

	#region Monobehaviour Callbacks
	private void Awake()
	{
		if(!instance || instance != this)
			instance = this;

		StartCoroutine(StartupEvent());
	}
	#endregion

	private IEnumerator StartupEvent()
	{
		characterGo.SetActive(false);
		cloudSpawnerGo.SetActive(false);
		overlayGo.SetActive(true);

		camGo.transform.position = new Vector3(0, 0, -10);
		characterGo.transform.position = new Vector3(0, 1, 0);
		cloudSpawnerGo.transform.position = Vector3.zero;

		yield return new WaitForSeconds(2f);

		camGo.gameObject.SetActive(true);
		characterGo.SetActive(true);
		cloudSpawnerGo.SetActive(true);
		overlayGo.SetActive(false);

		yield return null;
	}

	public void LoadMainScene()
	{
		SceneManager.LoadScene("Main");
	}
}
