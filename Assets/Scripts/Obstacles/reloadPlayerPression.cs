using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadPlayerPression : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerMovement>().pression = 100.0f;
        }
    }
}
