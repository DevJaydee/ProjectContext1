using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		if(eventData.pointerDrag != null)
		{
			Destroy(eventData.pointerDrag);
			Debug.Log("Dropped on the Monster!");
		}
	}
}
