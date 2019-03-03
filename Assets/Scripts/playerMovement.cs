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

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        foreach (Transform child in Smoke.transform)
        {
            SmokeEffect.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal;
        float moveVertical;
        float force;
        if(IsInputEnabled)
        {
            if (isPlayer1)
            {
                moveHorizontal = Input.GetAxis("J1_LeftStickHorizontal");
                moveVertical = Input.GetAxis("J1_LeftStickVertical");
                if (pression > 0)
                {
                    force = Input.GetAxis("J1_RightTrigger");
                }
                else
                {
                    if (Input.GetButtonDown("J1_AButton"))
                    {
                        force = mashForce;
                    }
                    else
                    {
                        force = 0.0f;
                    }
                    if (Input.GetButtonDown("J1_BButton"))
                    {
                        pression = 100.0f;
                    }
                }
            }
            else
            {
                moveHorizontal = Input.GetAxis("J2_LeftStickHorizontal");
                moveVertical = Input.GetAxis("J2_LeftStickVertical");
                if (pression > 0)
                {
                    force = Input.GetAxis("J2_RightTrigger");
                }
                else
                {
                    if (Input.GetButtonDown("J2_AButton"))
                    {
                        force = mashForce;
                    }
                    else
                    {
                        force = 0.0f;
                    }
                    if (Input.GetButtonDown("J2_BButton"))
                    {
                        pression = 100.0f;
                    }
                }
            }

            Vector3 orientation = new Vector3(moveHorizontal, moveVertical, 0.0f);

        if (orientation.magnitude > limitMag)
        {
            if (orientation == new Vector3(-1, 0, 0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180.0f);
            }
            else
            {
                transform.right = orientation;
            }

        }
        if (force != 0.0/* && pression > 0*/)
        {
            pression = pression - force / 10;
            rb.AddForce(force * transform.right * speed);
            if (pression > 0)
            {
                foreach (GameObject go in SmokeEffect)
                {
                    ParticleSystem psystem = go.GetComponent<ParticleSystem>();
                    if (!psystem.isPlaying)
                    {
                        psystem.loop = true;
                        psystem.Play();
                    }
                }
            }
            else
            {
                SmokeEffect[0].GetComponent<ParticleSystem>().Play();
            }


        }
        else
        {
            foreach (GameObject go in SmokeEffect)
            {
                ParticleSystem psystem = go.GetComponent<ParticleSystem>();
                if (psystem.isPlaying)
                {
                    psystem.loop = false;
                }
            }
        }
        if (pression < 0)
        {
            pression = 0;
        }

        if (mustDie)
        {
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
        mustDie = true;
        sphere.SetActive(true);
    }



    public IEnumerator canvasDeath()
    {
        float a = 0;

        yield return new WaitForSeconds(0.5f);
        deathMenu.SetActive(true);
        MenuHandler.setAlphaObject(deathMenu, 0);
        deathMenu.GetComponent<CanvasRenderer>().SetAlpha(0);
        while (a <= 1)
        {
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
}
