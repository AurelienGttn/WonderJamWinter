using System.Collections;
using UnityEngine;

public class EndMenuHandler : MonoBehaviour
{
    public GameObject contenant;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("updateRotation");
    }


    public IEnumerator updateRotation()
    {
        while (true)
        {
            contenant.transform.Rotate(new Vector3(0, 0, -3));
            contenant.transform.Rotate(new Vector3(0, 1, 0));
            yield return new WaitForSeconds(0.01f);

        }

    }
}
