using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class ItemDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[SerializeField] private Vector3 defaultPos = default;  // The default position of this item.
	[SerializeField] private bool draggingItem = false;     // Is the item currently being dragged?
	[Space]
	[SerializeField] private CanvasGroup canvasGroup = default; // Reference to the CanvasGroup.

	public bool DraggingItem { get => draggingItem; set => draggingItem = value; }

	private void Awake()
	{
		defaultPos = transform.position;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
		transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
		draggingItem = true;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;

		transform.position = defaultPos;
		transform.localScale = Vector3.one;
		draggingItem = false;
	}

}
