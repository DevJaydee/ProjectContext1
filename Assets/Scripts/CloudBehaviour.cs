using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
	[SerializeField] private GameObject character = default;

	private BoxCollider2D bc2d = default;

	private void Start()
	{
		bc2d = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		if(character.transform.position.y < transform.position.y )
		{

		}
	}
}
