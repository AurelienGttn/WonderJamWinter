using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float pression = 100.0f;

    public bool isPlayer1;

    private Rigidbody rb;
    private float limitMag = 0.3f;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
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
            force = Input.GetAxis("J1_RightTrigger");

            if (Input.GetButtonDown("J1_AButton"))
            {
                pression = 100.0f;
            }
        } else
        {
            moveHorizontal = Input.GetAxis("J2_LeftStickHorizontal");
            moveVertical = Input.GetAxis("J2_LeftStickVertical");
            force = Input.GetAxis("J2_RightTrigger");

            if (Input.GetButtonDown("J2_AButton"))
            {
                pression = 100.0f;
            }
        }
        

        Vector3 orientation = new Vector3(moveHorizontal, moveVertical, 0.0f);
        if(orientation.magnitude > limitMag)
        {
            transform.right = orientation;

            //transform.LookAt(orientation);
        }
        if(force != 0.0 && pression > 0)
        {
            pression = pression - force/10;
            rb.AddForce(force * transform.right * speed);
        }
        if(pression < 0)
        {
            pression = 0;
        }


    }
}
