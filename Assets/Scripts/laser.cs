using UnityEngine;

public class laser : MonoBehaviour
{
    public Vector3 velocity;
    private Rigidbody laserRigidbody;
    private bool mustDie = false;
    
    // Start is called before the first frame update
    void Start()
    {
        laserRigidbody = GetComponent<Rigidbody>();
        transform.forward = velocity;
        transform.Rotate(0, 90, 90);
    }

    // Update is called once per frame
    void Update()
    {
        laserRigidbody.velocity = velocity;
        if (mustDie)
        {
            GameObject.DestroyImmediate(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            
            collision.gameObject.GetComponent<playerMovement>().death();

        }
        mustDie = true;


    }
}
