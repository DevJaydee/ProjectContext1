﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TaskMenu : MonoBehaviour
{
	#region Variables
	[SerializeField] private GameObject dueDateDays = default;      // Reference to the dueDateDays gameobject.
	[SerializeField] private GameObject dueDateHours = default;     // Reference to the dueDateHours gameobject.
	[SerializeField] private GameObject dueDateMinutes = default;   // Reference to the dueDateMinutes gameobject.
	[Space]
	[SerializeField] private GameObject[] dueDateDaysButtons = default;     // Reference to all the buttons in the dueDateDays transform.
	[SerializeField] private GameObject[] dueDateHoursButtons = default;    // Reference to all the buttons in the dueDateHours transform.
	[SerializeField] private GameObject[] dueDateMinutesButtons = default;  // Reference to all the buttons in the dueDateMinutes transform.
	#endregion

	private void Start()
	{
		SetupDueDates();
	}

	private void SetupDueDates()
	{
		for(int i = 0; i < dueDateDaysButtons.Length; i++)
		{
			dueDateDaysButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
		}
		for(int i = 0; i < dueDateHoursButtons.Length; i++)
		{
			dueDateHoursButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
		}
		for(int i = 0; i < dueDateMinutesButtons.Length; i++)
		{
			dueDateMinutesButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
		}
	}

	public void SetDueDateDayOnClick()
	{
		GameObject buttonGO = EventSystem.current.currentSelectedGameObject;
		TaskManager.Instance.DueDateDayTemp = int.Parse(buttonGO.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
	}
	public void SetDueDateHoursOnClick()
	{
		GameObject buttonGO = EventSystem.current.currentSelectedGameObject;
		TaskManager.Instance.DueDateHoursTemp = int.Parse(buttonGO.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
	}
	public void SetDueDateMinutesOnClick()
	{
		GameObject buttonGO = EventSystem.current.currentSelectedGameObject;
		TaskManager.Instance.DueDateMinutesTemp = int.Parse(buttonGO.GetComponentInChildren<TMPro.TextMeshProUGUI>().text);
	}
}
