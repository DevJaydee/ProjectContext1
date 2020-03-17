using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskOverviewItem : MonoBehaviour
{
	#region Variables
	[SerializeField] private TextMeshProUGUI dueDateTextMesh = default;     // Reference to the Due Date Text Mesh.
	[SerializeField] private TextMeshProUGUI titleTextMesh = default;       // Reference to the Task Title.
	[Space]
	[SerializeField] private Image imageComp = default; // Reference to the Image component.
	[SerializeField] private Sprite sprite = default;   // The sprite for the task. This will be some type of food.
	[SerializeField] private string title = "";                             // Title of the Task Overview Item.
	[SerializeField] private int dueDateMinutes = 0;  // How many Minutes are left before the task is due.
	[SerializeField] private int dueDateHours = 0;    // How many Hours are left before the task is due.
	[SerializeField] private int dueDateDays = 0;     // How many Days are left before the task is due.

	[SerializeField] private float convertedTotalSecondsToDeadline = 0;
	[SerializeField] [Tooltip("DO NOT EDIT IN EDITOR!")] private float convertedMinutesToSecondDeadline = 0;
	[SerializeField] [Tooltip("DO NOT EDIT IN EDITOR!")] private float convertedHoursToSecondsDeadline = 0;
	[SerializeField] [Tooltip("DO NOT EDIT IN EDITOR!")] private float convertedDaysToSecondsDeadline = 0;
	#endregion

	#region Getters and Setters
	public string Title { get => title; set => title = value; }
	public int DueDateMinutes { get => dueDateMinutes; set => dueDateMinutes = value; }
	public int DueDateHours { get => dueDateHours; set => dueDateHours = value; }
	public int DueDateDays { get => dueDateDays; set => dueDateDays = value; }
	public Sprite Sprite { get => sprite; set => sprite = value; }
	#endregion

	public TaskOverviewItem(string _Title, Sprite _sprite, int _dueDateDays, int _dueDateHours, int _dueDateMinutes)
	{
		title = _Title;
		sprite = _sprite;

		dueDateDays = _dueDateDays;
		dueDateHours = _dueDateHours;
		dueDateMinutes = _dueDateMinutes;
	}

	private void Start()
	{
		convertedMinutesToSecondDeadline = dueDateMinutes * 60;
		convertedHoursToSecondsDeadline = dueDateHours * 3600;
		convertedDaysToSecondsDeadline = dueDateDays * 86400;
		convertedTotalSecondsToDeadline = convertedDaysToSecondsDeadline + convertedHoursToSecondsDeadline + convertedTotalSecondsToDeadline;

		titleTextMesh.text = title;
		imageComp.sprite = sprite;

		StartCoroutine(UpdateDueDateCounter());
	}

	private void Update()
	{
		// Only calculate the timers when they are above zero... Which is also fair.
		if(convertedMinutesToSecondDeadline > 0) convertedMinutesToSecondDeadline -= Time.deltaTime; else convertedMinutesToSecondDeadline = 0;
		if(convertedHoursToSecondsDeadline > 0) convertedHoursToSecondsDeadline -= Time.deltaTime; else convertedHoursToSecondsDeadline = 0;
		if(convertedDaysToSecondsDeadline > 0) convertedDaysToSecondsDeadline -= Time.deltaTime; else convertedDaysToSecondsDeadline = 0;
		if(convertedTotalSecondsToDeadline > 0) convertedTotalSecondsToDeadline -= Time.deltaTime; else convertedTotalSecondsToDeadline = 0;
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

			string dueDateDaysString = (convertedDaysToSecondsDeadline / 86400).ToString("F0");
			if(dueDateDays < 10) dueDateDaysString = "0" + dueDateDaysString;

			string dueDateHoursString = (convertedHoursToSecondsDeadline / 3600).ToString("F0");
			if(dueDateHours < 10) dueDateHoursString = "0" + dueDateHoursString;

			string dueDateMinutesString = (convertedMinutesToSecondDeadline / 60).ToString("F0");
			if(dueDateMinutes < 10) dueDateMinutesString = "0" + dueDateMinutesString;

			dueDateTextMesh.text = dueDateDaysString + ":" + dueDateHoursString + ":" + dueDateMinutesString;
			yield return new WaitForSeconds(1f);
		}
	}
}
