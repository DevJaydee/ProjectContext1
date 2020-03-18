using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rotation
{
	Landscape,
	Portrait
}

public class OnSceneLoadChangeRotation : MonoBehaviour
{
	[SerializeField] private Rotation rotation = Rotation.Landscape;

	private void Awake()
	{
		switch(rotation)
		{
			case Rotation.Landscape:
				Screen.orientation = ScreenOrientation.LandscapeLeft;
				break;
			case Rotation.Portrait:
				Screen.orientation = ScreenOrientation.Portrait;
				break;
			default:
				break;
		}
	}
}
