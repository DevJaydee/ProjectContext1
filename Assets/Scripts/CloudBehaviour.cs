using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject character = default;

	private BoxCollider2D boxColl = default;

	private void Start()
	{
		boxColl = this.GetComponent<BoxCollider2D>();
		character = CloudJumperSceneManager.Instance.CloudJumperCharacter;
	}

	private void Update()
	{
		if(character.GetComponent<CloudJumperCharacterController>().BottomOfChar.transform.position.y > boxColl.transform.position.y + boxColl.size.y)
			boxColl.enabled = true;
		else
			boxColl.enabled = false;
	}
}
