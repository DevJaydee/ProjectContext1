using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	[SerializeField] private CharacterBehaviour character = default;

	public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{
			if(eventData.pointerDrag.GetComponent<Task>().ConvertedTotalSecondsToDeadline > 0f)
				character.IncreaseHunger(eventData.pointerDrag.GetComponent<Task>().TaskHungerWorth);

			Destroy(eventData.pointerDrag);
			Debug.Log("Dropped on the Monster!");
		}
	}
}
