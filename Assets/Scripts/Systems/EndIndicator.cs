﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndIndicator : MonoBehaviour
{
	private Transform target;
	public float hideDistance;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("EndOfRace").transform;
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;

		if (dir.magnitude < hideDistance) {
			SetChildrenActive(false);
		} else {
			SetChildrenActive(true);
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

	}

	void SetChildrenActive(bool value)
	{
		foreach (Transform child in transform) {
			child.gameObject.SetActive(value);
		}
	}
}
