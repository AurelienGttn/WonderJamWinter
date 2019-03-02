using UnityEngine;

public class handPositionHandler : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;

    public float angle;

    // Update is called once per frame
    void Update()
    {

        leftArm.transform.localRotation = Quaternion.Euler(0, 0, 0);
        leftArm.transform.Rotate(0, 0, 35 * Mathf.Cos((angle) * Mathf.PI / 180));
        leftArm.transform.Rotate(angle, 0, 0);
        leftArm.transform.Rotate(0, angle, 0);

        rightArm.transform.localRotation = Quaternion.Euler(0, 0, 0);
        rightArm.transform.Rotate(0, 0, -35 * Mathf.Cos((angle) * Mathf.PI / 180));
        rightArm.transform.Rotate(angle, 0, 0);
        rightArm.transform.Rotate(0, -angle, 0);
    }
}
