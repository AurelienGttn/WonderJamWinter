using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrouNoir : MonoBehaviour
{
    private float rayonAttraction = 10.0f;
    [SerializeField] private float forceAttraction = 1500f;

    private Collider[] objetProche;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        objetProche = Physics.OverlapSphere(transform.position, rayonAttraction);
        foreach(Collider c in objetProche)
        {
            if(c.tag == "Player")
            {
                Vector3 forceDirection = transform.position - c.transform.position;
                float distance = Vector3.Distance(transform.position, c.transform.position);
                // apply force on target towards me
                c.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * (forceAttraction/distance) * Time.fixedDeltaTime);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Kill Player");
        }
    }
}
