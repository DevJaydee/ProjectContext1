﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// In which state the task currently is.
public enum TaskState
{
	Creating,
	Active,
	Done
}
public class Task : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	#region Variables
	[SerializeField] private TaskState state = TaskState.Creating;  // Reference to the TaskState enum;
	[Space]
	[SerializeField] private new string name = "";  // Name of the task.
	[SerializeField] private string description = "";   // Description for the task.
	[SerializeField] private int dueDateMinutes = 0;  // How many Minutes are left before the task is due.
	[SerializeField] private int dueDateHours = 0;    // How many Hours are left before the task is due.
	[SerializeField] private int dueDateDays = 0;     // How many Days are left before the task is due.
	[Space]
	[SerializeField] private Image imageComp = default; // Reference to the Image component.
	[SerializeField] private Sprite sprite = default;   // The sprite for the task. This will be some type of food.
	[SerializeField] private Sprite sprite_spoiled = default;   // The spoiled sprite for the task. This will be some type of food.
	[SerializeField] private TextMeshProUGUI dueDateCounter = default;  // The text element that shows the user how much time is left.
	[Space]
	[SerializeField] private float convertedTotalSecondsToDeadline = 0;
	[SerializeField] [Tooltip("DO NOT EDIT IN EDITOR!")] private float convertedMinutesToSecondDeadline = 0;
	[SerializeField] [Tooltip("DO NOT EDIT IN EDITOR!")] private float convertedHoursToSecondsDeadline = 0;
	[SerializeField] [Tooltip("DO NOT EDIT IN EDITOR!")] private float convertedDaysToSecondsDeadline = 0;
	[Space]
	[SerializeField] private float taskHungerWorth = 10;    // How much this wil fill the HungerBar with.
	#endregion

	#region Getters And Setters
	public TaskState State { get => state; set => state = value; }

	public string Name { get => name; set => name = value; }
	public string Description { get => description; set => description = value; }
	public int DueDateMinutes { get => dueDateMinutes; set => dueDateMinutes = value; }
	public int DueDataHours { get => dueDateHours; set => dueDateHours = value; }
	public int DueDateDays { get => dueDateDays; set => dueDateDays = value; }

	public Sprite Sprite { get => sprite; set => sprite = value; }
	public Sprite Sprite_spoiled { get => sprite_spoiled; set => sprite_spoiled = value; }
	public TextMeshProUGUI DueDateCounter { get => dueDateCounter; set => dueDateCounter = value; }

	public float ConvertedTotalSecondsToDeadline { get => convertedTotalSecondsToDeadline; set => convertedTotalSecondsToDeadline = value; }
	public float TaskHungerWorth { get => taskHungerWorth; set => taskHungerWorth = value; }
	#endregion

	#region Functions
	private void Start()
	{
		imageComp.sprite = sprite;

		convertedMinutesToSecondDeadline = dueDateMinutes * 60;
		convertedHoursToSecondsDeadline = dueDateHours * 3600;
		convertedDaysToSecondsDeadline = dueDateDays * 86400;

		StartCoroutine(UpdateDueDateCounter());
	}

	private void Update()
	{
		// Only calculate the timers when they are above zero... Which is also fair.
		if(convertedMinutesToSecondDeadline > 0) convertedMinutesToSecondDeadline -= Time.deltaTime; else convertedMinutesToSecondDeadline = 0;
		if(convertedHoursToSecondsDeadline > 0) convertedHoursToSecondsDeadline -= Time.deltaTime; else convertedHoursToSecondsDeadline = 0;
		if(convertedDaysToSecondsDeadline > 0) convertedDaysToSecondsDeadline -= Time.deltaTime; else convertedDaysToSecondsDeadline = 0;
		if(convertedTotalSecondsToDeadline > 0) convertedTotalSecondsToDeadline -= Time.deltaTime; else convertedTotalSecondsToDeadline = 0;
		convertedTotalSecondsToDeadline = convertedDaysToSecondsDeadline + convertedHoursToSecondsDeadline + convertedMinutesToSecondDeadline;

		if(convertedTotalSecondsToDeadline <= 0f)
			imageComp.sprite = sprite_spoiled;
	}

	/// <summary>
	/// Updates the Due Date counter in the game. Since this counter shows: Days, Hours and minutes, it is very much overkill to update the UI every frame.
	/// So this only update every second, which is fair.
	/// </summary>
	/// <returns></returns>
	private IEnumerator UpdateDueDateCounter()
	{
		while(true)
		{
			if(state == TaskState.Active)
			{
				string dueDateDaysString = Mathf.Ceil(convertedDaysToSecondsDeadline / 86400).ToString("F0");
				if(dueDateDays < 10) dueDateDaysString = "0" + dueDateDaysString;

				string dueDateHoursString = Mathf.Ceil(convertedHoursToSecondsDeadline / 3600).ToString("F0");
				if(dueDateHours < 10) dueDateHoursString = "0" + dueDateHoursString;

				string dueDateMinutesString = Mathf.Ceil(convertedMinutesToSecondDeadline / 60).ToString("F0");
				if(dueDateMinutes < 10) dueDateMinutesString = "0" + dueDateMinutesString;

				dueDateCounter.text = dueDateDaysString + ":" + dueDateHoursString + ":" + dueDateMinutesString;
			}
			yield return new WaitForSeconds(1f);
		}
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if(!GetComponent<ItemDragHandler>().DraggingItem)
			TaskManager.Instance.ToggleTaskMenuWithCurrentTaskData(name, description);
	}

	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		transform.localScale = transform.localScale *= 1.1f;
	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		transform.localScale = Vector3.one;
	}
	#endregion

	public Task(string _name, string _description, Sprite _sprite, Sprite _spriteSpoiled)
	{
		name = _name;
		description = _description;
		sprite = _sprite;
		sprite_spoiled = _spriteSpoiled;
	}
}
