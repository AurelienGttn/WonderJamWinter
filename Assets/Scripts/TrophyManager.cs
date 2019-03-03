using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrophyManager : MonoBehaviour
{
	private Image trophy;
	public Transform player1;
	public Transform player2;

	
	// Start is called before the first frame update
    void Start()
    {
		trophy = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
		float posXJ1 = player1.position.x;
		float posXJ2 = player2.position.x;

		float delta = (posXJ1 - posXJ2) * 3;
		float posYTrophy = Mathf.Clamp(delta, -300f, 300f);

		trophy.GetComponent<RectTransform>().localPosition = new Vector3(-870f, posYTrophy, 0f);
    }
}
