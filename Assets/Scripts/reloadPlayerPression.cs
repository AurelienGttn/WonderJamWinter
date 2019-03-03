using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadPlayerPression : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<playerMovement>().pression = 100.0f;
        }
    }
}
