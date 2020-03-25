using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour
{
	private static GyroControl instance = null;

	[SerializeField] private float smooth = 0.4f;
	[SerializeField] private float newRotation;
	[SerializeField] private float sensitivity = 6;
	[SerializeField] private Vector3 currentAcceleration;

	public static GyroControl Instance { get => instance; set => instance = value; }
	public float NewRotation { get => newRotation; set => newRotation = value; }

	private void Awake()
	{
		if(!instance || instance != this)
			instance = this;
	}

	private void Start()
	{
		currentAcceleration = Vector3.zero;
	}

	private void Update()
	{
		currentAcceleration = Input.acceleration;

		newRotation = Mathf.Clamp(currentAcceleration.x * sensitivity, -1, 1);
	}

	//protected void OnGUI()
	//{
	//	GUI.skin.label.fontSize = Screen.width / 40;

	//	GUILayout.Label("Orientation: " + Screen.orientation);
	//	GUILayout.Label("input.Accelerometer: " + Input.acceleration);
	//	GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
	//}
}
