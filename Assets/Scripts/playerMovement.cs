using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public float speed = 15.0f;
	public float pression = 100.0f;

	public bool isPlayer1;

	public GameObject Smoke;
	private List<GameObject> SmokeEffect = new List<GameObject>();

	private Rigidbody rb;
	private float limitMag = 0.3f;
	[SerializeField] private float mashForce = 10.0f;

	private bool mustDie = false;
	public static bool IsInputEnabled = false;

	public GameObject sphere;

	public GameObject deathMenu;

	private bool pushAsteroid = false;
	private float timeToPush;
	private bool isInCollision = false;
	private Vector3 velocityBeforePush;

	public Items item;
	public GameObject iconsJ1;
	public GameObject iconsJ2;



	// Start is called before the first frame update
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		foreach (Transform child in Smoke.transform) {
			SmokeEffect.Add(child.gameObject);
		}
	}

	// Update is called once per frame
	void Update()
	{
		float moveHorizontal;
		float moveVertical;
		float force;

		if (timeToPush > 0) {
			Debug.Log("Asteroid");
			timeToPush -= Time.deltaTime;

		}

		if (!isInCollision) {
			velocityBeforePush = GetComponent<Rigidbody>().velocity;
		}

		if (IsInputEnabled) {
			if (isPlayer1) {
				moveHorizontal = Input.GetAxis("J1_LeftStickHorizontal");
				moveVertical = Input.GetAxis("J1_LeftStickVertical");
				if (pression > 0) {
					force = Input.GetAxis("J1_RightTrigger");
				} else {
					if (Input.GetButtonDown("J1_AButton")) {
						force = mashForce;
					} else {
						force = 0.0f;
					}
					if (Input.GetButtonDown("J1_BButton")) {
						// Déclanchment de l'item
						//pression = 100.0f;
						item.run(isPlayer1);
						foreach (Transform child in iconsJ1.transform) {
							child.gameObject.SetActive(false);
						}
					}
				}
			} else {
				moveHorizontal = Input.GetAxis("J2_LeftStickHorizontal");
				moveVertical = Input.GetAxis("J2_LeftStickVertical");
				if (pression > 0) {
					force = Input.GetAxis("J2_RightTrigger");
				} else {
					if (Input.GetButtonDown("J2_AButton")) {
						force = mashForce;
					} else {
						force = 0.0f;
					}
					if (Input.GetButtonDown("J2_BButton")) {
						//pression = 100.0f;
						item.run(isPlayer1);
						foreach(Transform child in iconsJ2.transform) {
							child.gameObject.SetActive(false);
						}
					}
				}
			}

			Vector3 orientation = new Vector3(moveHorizontal, moveVertical, 0.0f);

			if (orientation.magnitude > limitMag) {
				if (orientation == new Vector3(-1, 0, 0)) {
					transform.rotation = Quaternion.Euler(0, 0, 180.0f);
				} else {
					transform.right = orientation;
				}

			}
			if (force != 0.0/* && pression > 0*/) {
				pression = pression - force / 10;
				rb.AddForce(force * transform.right * speed);
				if (pression > 0) {
					foreach (GameObject go in SmokeEffect) {
						ParticleSystem psystem = go.GetComponent<ParticleSystem>();
						if (!psystem.isPlaying) {
							psystem.loop = true;
							psystem.Play();
						}
					}
				} else {
					SmokeEffect[0].GetComponent<ParticleSystem>().Play();
				}


			} else {
				foreach (GameObject go in SmokeEffect) {
					ParticleSystem psystem = go.GetComponent<ParticleSystem>();
					if (psystem.isPlaying) {
						psystem.loop = false;
					}
				}
			}
			if (pression < 0) {
				pression = 0;
			}

			if (mustDie) {
				//gameObject.SetActive(false);
				GetComponent<Rigidbody>().freezeRotation = false;
				GetComponent<Rigidbody>().angularDrag = 0;
				GetComponent<Rigidbody>().drag = 0;
				GetComponent<Rigidbody>().AddTorque(10, 10, 10);
				StartCoroutine("canvasDeath");
				gameObject.GetComponent<playerMovement>().enabled = false;
			}
		}




	}

	public void death()
	{
		if (!ItemInvulnerabilite.isInvulnerable) {
			mustDie = true;
			sphere.SetActive(true);
		}
	}



	public IEnumerator canvasDeath()
	{
		float a = 0;

		yield return new WaitForSeconds(0.5f);
		deathMenu.SetActive(true);
		MenuHandler.setAlphaObject(deathMenu, 0);
		deathMenu.GetComponent<CanvasRenderer>().SetAlpha(0);
		while (a <= 1) {
			yield return new WaitForSeconds(0.01f);
			MenuHandler.setAlphaObject(deathMenu, a);
			deathMenu.GetComponent<CanvasRenderer>().SetAlpha(a);
			a += 0.05f;
		}

	}

	private void OnDrawGizmos()
	{

		Gizmos.color = Color.yellow;
		Vector3 offset = new Vector3(80, 0, 0);
		//Gizmos.DrawSphere(transform.position + offset, 30);
	}

	public void pushAsteroids(float time)
	{
		pushAsteroid = true;
		timeToPush = time;
	}

	public void OnCollisionEnter(Collision collision)
	{
		isInCollision = true;
		if (timeToPush > 0 && pushAsteroid) {
			Rigidbody asterRigid = collision.gameObject.GetComponent<Rigidbody>();
			if (collision.gameObject.tag == "Asteroïde" && asterRigid != null) {
				asterRigid.velocity = velocityBeforePush * (asterRigid.velocity.magnitude / velocityBeforePush.magnitude);
			}

		}
	}

	public void OnCollisionExit(Collision collision)
	{
		if (timeToPush > 0 && pushAsteroid) {
			if (collision.gameObject.tag == "Asteroïde") {
				GetComponent<Rigidbody>().velocity = velocityBeforePush;
			}

		}
		isInCollision = false;
	}
}
