using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudJumperSceneManager : MonoBehaviour
{
	#region Variables
	private static CloudJumperSceneManager instance = null;

	[SerializeField] private GameObject cloudJumperCharacter = default;     // Reference to the Cloud Jumper Character.
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
	}
	#endregion
}
