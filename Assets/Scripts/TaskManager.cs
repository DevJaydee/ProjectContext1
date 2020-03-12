using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
	#region Variables
	private static TaskManager instance = null;                             // An instance of this behaviour.
	[SerializeField] private Sprite[] foodSprites = default;				// Array with all the Food Sprites.
	[SerializeField] private Sprite[] spoiledFoodSprites = default;          // Array with all the Spoiled Food Sprites.
	[Space]
	[SerializeField] private TMP_InputField taskNameInput = default;        // Reference to the Inputfield with the task name.
	[SerializeField] private TMP_InputField taskDescriptionInput = default; // Reference to the Inputfield for the task description.
	[Space]
	[SerializeField] private GameObject TaskPrefab = default;               // The prefab task Gameobject.
	[SerializeField] private GameObject taskMenu = default;                 // The Add Task Menu.
	[SerializeField] private GameObject taskMenuAddButton = default;        // Reference to the Add button on the TaskMenu.
	[SerializeField] private List<Task> activeTasks = new List<Task>();     // List with all the active tasks.
	[SerializeField] private List<GameObject> activeTaskObjects = new List<GameObject>();     // List with all the active task Gameobjects.
	[SerializeField] private GameObject[] taskParents = default;            // Array with all the gameobjects which can be a parent to a task.
	[Space]
	[SerializeField] private GameObject characterGO = default;				// Reference to the Character Gameobject.
	private int dueDateDayTemp = 0;
	private int dueDateHoursTemp = 0;
	private int dueDateMinutesTemp = 0;
	#endregion

	#region Getters and Setters
	public static TaskManager Instance { get => instance; set => instance = value; }
	public int DueDateDayTemp { get => dueDateDayTemp; set => dueDateDayTemp = value; }
	public int DueDateHoursTemp { get => dueDateHoursTemp; set => dueDateHoursTemp = value; }
	public int DueDateMinutesTemp { get => dueDateMinutesTemp; set => dueDateMinutesTemp = value; }
	public GameObject CharacterGO { get => characterGO; set => characterGO = value; }
	public Sprite[] FoodImages { get => foodSprites; set => foodSprites = value; }
	public Sprite[] SpoiledFoodImages { get => spoiledFoodSprites; set => spoiledFoodSprites = value; }
	#endregion

	#region Monobehaviour Callbacks
	private void Awake()
	{
		if(!instance || instance != this)
			instance = this;
	}

	private void Start()
	{
		taskMenu.SetActive(false);
	}
	#endregion

	/// <summary>
	/// Opens the Add Task Menu (As the name implies).
	/// Within the menu the user can add: Name, Description and Due Date.
	/// </summary>
	public void ToggleAddTaskMenu()
	{
		CleanTaskMenu();

		taskNameInput.interactable = true;
		taskDescriptionInput.interactable = true;
		taskMenuAddButton.SetActive(true);

		taskMenu.SetActive(!taskMenu.activeInHierarchy);
	}

	/// <summary>
	/// Opens the Task menu. But, this will only be called from the tasks itself.
	/// This opens the tasks that gets clicked and loads the current task data into the menu.
	/// Since this is purely for info, interaction with the inputfields are disabled and the add food button is removed.
	/// </summary>
	/// <param name="_name"></param>
	/// <param name="_description"></param>
	public void ToggleTaskMenuWithCurrentTaskData(string _name, string _description)
	{
		CleanTaskMenu();

		taskNameInput.text = _name;
		taskNameInput.interactable = false;

		taskDescriptionInput.text = _description;
		taskDescriptionInput.interactable = false;

		taskMenuAddButton.SetActive(false);

		taskMenu.SetActive(!taskMenu.activeInHierarchy);
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

		newTaskGO.GetComponent<Task>().DueDateDays = dueDateDayTemp;
		newTaskGO.GetComponent<Task>().DueDataHours = dueDateHoursTemp;
		newTaskGO.GetComponent<Task>().DueDateMinutes = dueDateMinutesTemp;

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
