using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudJumperCharacterController : MonoBehaviour
{
	[SerializeField] private float jumpForce = 10f;
	[SerializeField] private Rigidbody2D rb = default;
	[SerializeField] private float moveDir = 0;
	[SerializeField] private float movespeed = 10000;
	[SerializeField] private float maxVelocity;
	[SerializeField] private float jumpCooldown = 1.5f;
	[SerializeField] private bool canJump = true;
	[Space]
	[SerializeField] private Transform bottomOfChar = default;

	public float MoveDir { get => moveDir; set => moveDir = value; }
	public Transform BottomOfChar { get => bottomOfChar; set => bottomOfChar = value; }

	private void Update()
	{
		moveDir = GyroControl.Instance.NewRotation;
		Vector3 pos = transform.position;

		rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);

		float dist = (transform.position - Camera.main.transform.position).z;
		float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		transform.Translate(new Vector3(moveDir * movespeed * Time.deltaTime, 0, 0));

		pos.x = Mathf.Clamp(transform.position.x, leftBorder, rightBorder);
		transform.position = pos;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Cloud") && canJump)
		{
			rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
			StartCoroutine(StartJumpCooldown());
			Debug.Log("Jumped!");
		}
	}

	private IEnumerator StartJumpCooldown()
	{
		canJump = false;
		yield return new WaitForSeconds(jumpCooldown);
		canJump = true;
	}
}
