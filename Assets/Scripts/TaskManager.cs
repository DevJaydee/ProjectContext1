using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
	#region Variables
	[SerializeField] private TMP_InputField taskNameInput = default;        // Reference to the Inputfield with the task name.
	[SerializeField] private TMP_InputField taskDescriptionInput = default; // Reference to the Inputfield for the task description.
	[Space]
	[SerializeField] private List<Task> activeTasks = new List<Task>();     // List with all the active tasks.
	[SerializeField] private GameObject[] taskParents = default;			// Array with all the gameobjects which can be a parent to a task.
	#endregion

	public void AddTask()
	{
		string _name = taskNameInput.text;
		string _description = taskDescriptionInput.text;

		Task newTask = new Task(_name, _description);

		activeTasks.Add(newTask);
	}
}
