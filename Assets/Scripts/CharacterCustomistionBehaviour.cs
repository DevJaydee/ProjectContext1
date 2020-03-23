using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCustomistionBehaviour : MonoBehaviour
{
	[SerializeField] private Transform headTransform = default;
	[SerializeField] private int headChildIndex = 0;
	[Space]
	[SerializeField] private Transform torsoTransform = default;
	[SerializeField] private int torsoChildIndex = 0;
	[Space]
	[SerializeField] private Transform legsTransform = default;
	[SerializeField] private int legsChildIndex = 0;

	private void Start()
	{
		SelectHead(0);
		SelectTorso(0);
		SelectLegs(0);
	}

	public void SelectHead(int indexChange)
	{
		headChildIndex += indexChange;
		if(headChildIndex > headTransform.childCount - 1)
			headChildIndex = 0;
		if(headChildIndex < 0)
			headChildIndex = headTransform.childCount - 1;

		for(int i = 0; i < headTransform.childCount; i++)
		{
			if(i == headChildIndex)
				headTransform.GetChild(i).gameObject.SetActive(true);
			else
				headTransform.GetChild(i).gameObject.SetActive(false);
		}
	}
	public void SelectTorso(int indexChange)
	{
		torsoChildIndex += indexChange;
		if(torsoChildIndex > torsoTransform.childCount - 1)
			torsoChildIndex = 0;
		if(torsoChildIndex < 0)
			torsoChildIndex = torsoTransform.childCount - 1;

		for(int i = 0; i < torsoTransform.childCount; i++)
		{
			if(i == torsoChildIndex)
				torsoTransform.GetChild(i).gameObject.SetActive(true);
			else
				torsoTransform.GetChild(i).gameObject.SetActive(false);
		}
	}
	public void SelectLegs(int indexChange)
	{
		legsChildIndex += indexChange;
		if(legsChildIndex > legsTransform.childCount - 1)
			legsChildIndex = 0;
		if(legsChildIndex < 0)
			legsChildIndex = legsTransform.childCount - 1;

		for(int i = 0; i < legsTransform.childCount; i++)
		{
			if(i == legsChildIndex)
				legsTransform.GetChild(i).gameObject.SetActive(true);
			else
				legsTransform.GetChild(i).gameObject.SetActive(false);
		}
	}

}