using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
	[SerializeField] private Transform target = default;
	[SerializeField] private float smoothing = 7.5f;
	[SerializeField] private Vector3 offset = Vector3.zero;

	private Vector3 desiredPos;
	private Vector3 smoothedPos;

	private void Update()
	{
		if(target)
		{
			desiredPos = target.position + offset;
			smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothing * Time.deltaTime);
		}
	}

	private void FixedUpdate()
	{
		if(target)
			transform.position = smoothedPos;
	}
}
