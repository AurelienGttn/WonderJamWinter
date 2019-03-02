using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrouNoir : MonoBehaviour
{
    public float rayonAttraction = 5.0f;

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
            Debug.Log(c.gameObject.name);
            if(c.tag == "Player")
            {
                Vector3 forceDirection = transform.position - c.transform.position;

                // apply force on target towards me
                c.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * 200 * Time.fixedDeltaTime);

            }
        }
    }
}
