using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscButtonsManager : MonoBehaviour
{
	[SerializeField] private GameObject miniGamesMenu = default;        // Reference to the MiniGamesMenu gameobject.

	private void Start()
	{
		miniGamesMenu.SetActive(false);
	}

	public void ToggleMiniGamesMenu()
	{
		miniGamesMenu.SetActive(!miniGamesMenu.activeInHierarchy);
	}

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
