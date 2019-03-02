using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestFillAreaIndicator : MonoBehaviour
{
	public float minHideDistance;
	public float maxHideDistance;
	private GameObject[] fillAreas;
	private Transform closestFillArea;

	// Start is called before the first frame update
	void Start()
	{
		fillAreas = GameObject.FindGameObjectsWithTag("Station");
		closestFillArea = fillAreas[0].transform;
		InvokeRepeating("GetClosestFillArea", 0.0f, 1.0f);
	}

	private void Update()
	{
		Vector3 dir = closestFillArea.position - transform.position;

		if (dir.magnitude < minHideDistance || dir.magnitude > maxHideDistance) {
			SetChildrenActive(false);
		} else {
			SetChildrenActive(true);
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}
	}

	// Update is called once per frame
	void GetClosestFillArea()
    {
        fillAreas = GameObject.FindGameObjectsWithTag("Station");
        closestFillArea = fillAreas[0].transform;

        float closestDistance = float.MaxValue;
		foreach (GameObject fillArea in fillAreas) {
			Transform currentFillArea = fillArea.transform;
			float currentDistance = Vector3.Distance(transform.position, currentFillArea.position);
			if (currentDistance < closestDistance) {
				closestDistance = currentDistance;
				closestFillArea = currentFillArea;
			}
		}

	}

	void SetChildrenActive(bool value)
	{
		foreach (Transform child in transform) {
			child.gameObject.SetActive(value);
		}
	}
}
