using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float pression = 100.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float force = Input.GetAxis("J1_");
        

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if(movement != Vector3.zero)
        {
            transform.forward = - movement;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            pression = pression - 0.01f;
            rb.AddForce(movement * speed);
        }

    }
}
