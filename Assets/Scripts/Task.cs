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
public class Task : MonoBehaviour, IPointerDownHandler
{
	#region Variables
	[SerializeField] private TaskState state = TaskState.Creating;  // Reference to the TaskState enum;
	[Space]
	[SerializeField] private new string name = "";  // Name of the task.
	[SerializeField] private string description = "";   // Description for the task.
	[SerializeField] private float dueDateMinutes = 0;  // How many Minutes are left before the task is due.
	[SerializeField] private float dueDataHours = 0;    // How many Hours are left before the task is due.
	[SerializeField] private float dueDateDays = 0;     // How many Days are left before the task is due.
	[Space]
	[SerializeField] private Image image = default;   // The image for the task. This will be some type of food.
	[SerializeField] private TextMeshProUGUI dueDateCounter = default;  // The text element that shows the user how much time is left.
	#endregion

	#region Getters And Setters
	public TaskState State { get => state; set => state = value; }

	public string Name { get => name; set => name = value; }
	public string Description { get => description; set => description = value; }
	public float DueDateMinutes { get => dueDateMinutes; set => dueDateMinutes = value; }
	public float DueDataHours { get => dueDataHours; set => dueDataHours = value; }
	public float DueDateDays { get => dueDateDays; set => dueDateDays = value; }

	public Image Image { get => image; set => image = value; }
	public TextMeshProUGUI DueDateCounter { get => dueDateCounter; set => dueDateCounter = value; }
	#endregion

	#region Monobehaviour Callbacks
	private void Update()
	{
		if(state == TaskState.Active)
		{

		}
	}

	void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
	{
		TaskManager.Instance.ToggleTaskMenuWithCurrentTaskData(name, description);
	}
	#endregion

	public Task(string _name, string _description)
	{
		name = _name;
		description = _description;
	}
}
