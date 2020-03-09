using System.Collections;
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
public class Task : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
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
	[SerializeField] private Image image = default;   // The image for the task. This will be some type of food.
	[SerializeField] private TextMeshProUGUI dueDateCounter = default;  // The text element that shows the user how much time is left.

	private float convertedMinutesToSecondDeadline = 0;
	private float convertedHoursToSecondsDeadline = 0;
	private float convertedDaysToSecondsDeadline = 0;
	#endregion

	#region Getters And Setters
	public TaskState State { get => state; set => state = value; }

	public string Name { get => name; set => name = value; }
	public string Description { get => description; set => description = value; }
	public int DueDateMinutes { get => dueDateMinutes; set => dueDateMinutes = value; }
	public int DueDataHours { get => dueDateHours; set => dueDateHours = value; }
	public int DueDateDays { get => dueDateDays; set => dueDateDays = value; }

	public Image Image { get => image; set => image = value; }
	public TextMeshProUGUI DueDateCounter { get => dueDateCounter; set => dueDateCounter = value; }
	#endregion

	#region Monobehaviour Callbacks
	private void Start()
	{
		convertedMinutesToSecondDeadline = dueDateMinutes * 60;
		convertedHoursToSecondsDeadline = dueDateHours * 3600;
		convertedDaysToSecondsDeadline = dueDateDays * 86400;
	}

	private void Update()
	{
		if(state == TaskState.Active)
		{
			convertedMinutesToSecondDeadline -= Time.deltaTime;
			convertedHoursToSecondsDeadline -= Time.deltaTime;
			convertedDaysToSecondsDeadline -= Time.deltaTime;

			string dueDateDaysString = (convertedDaysToSecondsDeadline / 86400).ToString("F0");
			if(dueDateDays < 10) dueDateDaysString = "0" + dueDateDaysString;

			string dueDateHoursString = (convertedHoursToSecondsDeadline / 3600).ToString("F0");
			if(dueDateHours < 10) dueDateHoursString = "0" + dueDateHoursString;

			string dueDateMinutesString = (convertedMinutesToSecondDeadline / 60).ToString("F0");
			if(dueDateMinutes < 10) dueDateMinutesString = "0" + dueDateMinutesString;


			dueDateCounter.text = dueDateDaysString + ":" + dueDateHoursString + ":" + dueDateMinutesString;
		}
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
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

	public Task(string _name, string _description)
	{
		name = _name;
		description = _description;
	}
}
