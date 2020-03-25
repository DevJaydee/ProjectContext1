using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject character = default;

	private BoxCollider2D boxColl = default;

	private void Start()
	{
		this.boxColl = this.GetComponent<BoxCollider2D>();
		this.character = CloudJumperSceneManager.Instance.CloudJumperCharacter;
	}

	private void Update()
	{
		if(character.GetComponent<CloudJumperCharacterController>().BottomOfChar.transform.position.y > this.boxColl.transform.position.y + (this.boxColl.size.y / 2))
			this.boxColl.enabled = true;
		else
			this.boxColl.enabled = false;
	}
}
