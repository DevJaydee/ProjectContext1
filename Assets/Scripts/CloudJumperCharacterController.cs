using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudJumperCharacterController : MonoBehaviour
{
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private Rigidbody2D rb = default;
	[SerializeField] private float moveDir = 0;
	[SerializeField] private float movespeed = 10000;

	public float MoveDir { get => moveDir; set => moveDir = value; }

	private void Update()
	{
		moveDir = GyroControl.Instance.NewRotation;
		Vector3 pos = transform.position;

		float dist = (transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		if(moveDir > -0.8)
			rb.AddForce(Vector3.right * movespeed * Time.deltaTime);
		if(moveDir < 0.8)
			rb.AddForce(-Vector3.right * movespeed * Time.deltaTime);

		pos.x = Mathf.Clamp(transform.position.x, leftBorder, rightBorder);
		transform.position = pos;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Cloud"))
		{
			rb.AddForce(Vector3.up * jumpForce);
			Debug.Log("Jumped!");
		}
	}
}
