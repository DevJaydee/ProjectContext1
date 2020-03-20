using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	[SerializeField] private CharacterBehaviour character = default;

	public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{
			character.IncreaseHunger(eventData.pointerDrag.GetComponent<Task>().TaskHungerWorth);
			Destroy(eventData.pointerDrag);
			Debug.Log("Dropped on the Monster!");
		}
	}
}
