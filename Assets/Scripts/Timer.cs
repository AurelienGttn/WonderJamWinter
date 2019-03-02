using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Slider oxygenSlider;
	public float duration = 120f;
	private float timer;

	// Start is called before the first frame update
	void Start()
	{
		timer = duration;
	}

	// Update is called once per frame
	void Update()
	{
		timer -= Time.deltaTime;
		float progress = Map(timer, 0f, duration, 0f, 1f);
		oxygenSlider.value = progress;

		if (timer <= 0) {
			EndOfTimer();
		}
	}

	void EndOfTimer()
	{
		Debug.Log("Fin du timer");
	}


	float Map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
	}
}
