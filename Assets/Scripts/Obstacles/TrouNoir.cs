using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrouNoir : MonoBehaviour
{
    private float rayonAttraction = 10.0f;
    [SerializeField] private float forceAttraction = 1500f;

    private Collider[] objetProche;

    void Update()
    {
        objetProche = Physics.OverlapSphere(transform.position, rayonAttraction);
        foreach(Collider c in objetProche)
        {
            if(c.CompareTag("Player"))
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
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerMovement>().death();
        }
    }
}
