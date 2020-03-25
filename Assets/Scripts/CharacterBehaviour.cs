using Assets.SimpleAndroidNotifications;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviour : MonoBehaviour
{
	#region Variables
	// The max amount of the hunger bar (60 = full, no food needed)
	// The reason why it's 60, is because this way we can very easily calculate the hungerrate. Because 60 = minutes and hours..
	// 60 seconds in 1 minutes, 60 minutes in 1 hours.
	[SerializeField] private float hungerBarValue = 60;
	[SerializeField] [Tooltip("How much each SECOND this will decrease the hunger bar value, if hungerRate = 1, then it takes 1 away over 1 second.")] private float hungerRate = 0.001f;
	[Space]
	[SerializeField] private Image sliderImage = default;       // Reference to the image that will visualize the hunger of the character
	#endregion

	#region Monobehaviour Callbacks
	private void Update()
	{
		DecreaseHunger();
	}
	#endregion

	#region Voids
	private void DecreaseHunger()
	{
		if(TaskManager.Instance.ActiveTasks.Count > 0)
		{
			if(hungerBarValue > 0)
				hungerBarValue -= hungerRate * Time.deltaTime;
			else
				hungerBarValue = 0;

			//if(hungerBarValue <= 25 && hungerBarValue >= 24)
			//	ScheduleCustom();

			sliderImage.fillAmount = hungerBarValue / 60;
		}
	}

	public void IncreaseHunger(float amount)
	{
		hungerBarValue += amount;
		if(hungerBarValue > 60)
			hungerBarValue = 60;
	}

	public void ScheduleCustom()
	{
		var notificationParams = new NotificationParams
		{
			Id = UnityEngine.Random.Range(0, int.MaxValue),
			Title = "Your monster needs attention!",
			Message = "Your monster is very hungry maybe you should finish a task",
			Ticker = "Ticker",
			Sound = true,
			Vibrate = true,
			Light = true,
			SmallIcon = NotificationIcon.Bell,
			SmallIconColor = new Color(0, 0.5f, 0),
			LargeIcon = "app_icon"
		};

		NotificationManager.SendCustom(notificationParams);
	}
	#endregion
}
