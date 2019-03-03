using UnityEngine;

public class EndMenuHandler : MonoBehaviour
{
    public GameObject contenant;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        contenant.transform.Rotate(new Vector3(0, 0, -3));
        contenant.transform.Rotate(new Vector3(0, 1, 0));
    }
}
