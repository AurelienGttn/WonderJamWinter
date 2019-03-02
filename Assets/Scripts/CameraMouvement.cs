using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : MonoBehaviour
{

    public GameObject player;
    public float offsetZ;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, offsetZ);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, offsetZ);
    }
}
