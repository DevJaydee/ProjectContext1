using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
	#region Variables
	[SerializeField] private TMP_InputField taskNameInput = default;        // Reference to the Inputfield with the task name.
	[SerializeField] private TMP_InputField taskDescriptionInput = default; // Reference to the Inputfield for the task description.
	[Space]
	[SerializeField] private GameObject TaskPrefab = default;               // The prefab task Gameobject.
	[SerializeField] private GameObject addTaskMenu = default;              // The Add Task Menu.
	[SerializeField] private List<Task> activeTasks = new List<Task>();     // List with all the active tasks.
	[SerializeField] private List<GameObject> activeTaskObjects = new List<GameObject>();     // List with all the active task Gameobjects.
	[SerializeField] private GameObject[] taskParents = default;            // Array with all the gameobjects which can be a parent to a task.
	#endregion

	#region Monobehaviour Callbacks
	private void Start()
	{
		addTaskMenu.SetActive(false);
	}
	#endregion

	/// <summary>
	/// Opens the Add Task Menu (As the name implies).
	/// Within the menu the user can add: Name, Description and Due Date.
	/// </summary>
	public void ToggleAddTaskMenu()
	{
		addTaskMenu.SetActive(!addTaskMenu.activeInHierarchy);
	}

	/// <summary>
	/// This adds a Task to the activeTasks list and also visually to the Scene.
	/// This function get's all the info from the Input fields and calendar on the Add Task Menu.
	/// </summary>
	public void AddTask()
	{
		if(taskNameInput.text == "" || taskDescriptionInput.text == "")
			return;

		string _name = taskNameInput.text;
		string _description = taskDescriptionInput.text;

		GameObject taskParent = GetParentWithSpace();
		GameObject newTaskGO = Instantiate(TaskPrefab, taskParent.transform, false);

		Task newTask = new Task(_name, _description);

		newTaskGO.GetComponent<Task>().Name = newTask.Name;
		newTaskGO.GetComponent<Task>().Description = newTask.Description;
		newTaskGO.GetComponent<Task>().State = TaskState.Active;

		activeTasks.Add(newTask);
		activeTaskObjects.Add(newTaskGO);

		ToggleAddTaskMenu();
		CleanTaskMenu();
	}

	/// <summary>
	/// Finds a parent object with space for a task. This returns an Gameobject with space.
	/// </summary>
	/// <returns></returns>
	private GameObject GetParentWithSpace()
	{
		for(int i = 0; i < taskParents.Length; i++)
		{
			if(taskParents[i].transform.childCount < 3)
			{
				return taskParents[i];
			}
		}
		Debug.Log("No more Space left for tasks!");
		return null;
	}

	private void CleanTaskMenu()
	{
		taskNameInput.text = "";
		taskDescriptionInput.text = "";
	}
}
