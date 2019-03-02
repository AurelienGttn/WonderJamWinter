using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float pression = 100.0f;

    public bool isPlayer1;

    public GameObject Smoke;
    private List<GameObject> SmokeEffect = new List<GameObject>();

    private Rigidbody rb;
    private float limitMag = 0.3f;
    private float mashForce = 10.0f;

    private bool mustDie = false;

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
        if (isPlayer1)
        {
            moveHorizontal = Input.GetAxis("J1_LeftStickHorizontal");
            moveVertical = Input.GetAxis("J1_LeftStickVertical");
            if(pression > 0)
            {
            force = Input.GetAxis("J1_RightTrigger");
            } else
            {
            if (Input.GetButtonDown("J1_AButton"))
            {
                    force = mashForce;
                } else
                {
                    force = 0.0f;
                }
                if (Input.GetButtonDown("J1_BButton"))
                {
                pression = 100.0f;
            }
        } else        {
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
            if(orientation == new Vector3(-1,0,0))
            {
                transform.rotation = Quaternion.Euler(0, 0, 180.0f);
            } else
            {
            transform.right = orientation;
            }

        }
        if(force != 0.0/* && pression > 0*/)
        {
            Debug.Log(force);
            pression = pression - force / 10;
            rb.AddForce(force * transform.right * speed);
            if(pression > 0 )
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
            } else
            {
                SmokeEffect[0].GetComponent<ParticleSystem>().Play();
            }
            
            
        } else
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
            gameObject.SetActive(false);
        }

    }

    public void death()
    {
        mustDie = true;
    }
}
