using UnityEngine;

public class IAVaisseaux : MonoBehaviour
{
    private Rigidbody spaceshipRigidBody;
    public float maxDistanceDetection = 5;
    public float forceFactor = 2;
    public float maxVelocity = 5;
    private GameObject[] Players;
    public GameObject laser;
    [SerializeField] private Transform laserParent;
    private float lastTimeShoot = 0;
    public float laserVelocity = 5;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        spaceshipRigidBody = GetComponent<Rigidbody>();
        Players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //si on est proche d'un asteroides 
        //on l'évite
        checkForAsteroids();

        //on check si la vélocité n'est pas trop grande
        checkVelocity();

        //sinon
        //si un joueur est proche
        //on se tourne vers lui
        turnToNearPlayer();
    }

    public void checkForAsteroids()
    {
        RaycastHit ray;
        Vector3 force;
        Vector3 res = Vector3.zero;
        for (int i = 0; i <= 360; i += 30)
        {
            Vector3 destination = Quaternion.Euler(0, 0, i) * (new Vector3(0, maxDistanceDetection));
            if (Physics.Raycast(transform.position, destination, out ray, maxDistanceDetection))
            {
                if (ray.transform.tag == "Asteroïde")
                {
                    force = (transform.position - ray.transform.position).normalized;
                    force.Scale(new Vector3(forceFactor, forceFactor, 0));
                    spaceshipRigidBody.AddForceAtPosition(force, transform.position);
                }

                if (ray.transform.tag == "Player" && Mathf.Abs((ray.transform.position - transform.position).magnitude) < 1)
                {
                    force = (transform.position - ray.transform.position).normalized;
                    force.Scale(new Vector3(forceFactor / 5, forceFactor / 5, 0));
                    spaceshipRigidBody.AddForceAtPosition(force, transform.position);

                }
            }
        }
    }

    public void checkVelocity()
    {
        if (spaceshipRigidBody.velocity.magnitude > maxVelocity)
        {
            spaceshipRigidBody.velocity = spaceshipRigidBody.velocity - spaceshipRigidBody.velocity * (spaceshipRigidBody.velocity.magnitude - maxVelocity);
        }
    }

    public void turnToNearPlayer()
    {
        RaycastHit ray;
        Vector3 torque = new Vector3();
        float angle;
        for (int i = 0; i <= 360; i += 5)
        {
            Vector3 destination = Quaternion.Euler(0, 0, i) * (new Vector3(0, maxDistanceDetection));

            if (Physics.Raycast(transform.position, destination, out ray, maxDistanceDetection))
            {
                if (ray.transform.tag == "Player" && isTheNearestPlayer(ray.transform.gameObject))
                {
                    angle = Vector3.SignedAngle((ray.transform.position - transform.position), transform.right, new Vector3(0, 0, 1));
                    torque.z = -angle;
                    torque.x = 0;
                    torque.y = 0;
                    spaceshipRigidBody.AddTorque(torque);


                    if (Mathf.Abs(angle) < 10 && Time.time - lastTimeShoot > 1)
                    {
                        GameObject newLaser = Instantiate(laser, laserParent);
                        newLaser.transform.position = transform.position;
                        newLaser.GetComponent<laser>().velocity = (ray.transform.position - transform.position).normalized;
                        newLaser.GetComponent<laser>().velocity.Scale(new Vector3(laserVelocity, laserVelocity, laserVelocity));
                        lastTimeShoot = Time.time;
                    }

                }
            }
        }
    }


    public bool isTheNearestPlayer(GameObject player)
    {
        GameObject otherPlayer;
        if (player == Players[0])
        {
            otherPlayer = Players[1];
        }
        else
        {
            if (player == Players[1])
            {
                otherPlayer = Players[0];
            }
            else
            {
                return false;
            }

        }


        if (Mathf.Abs((player.transform.position - transform.position).magnitude) > Mathf.Abs((otherPlayer.transform.position - transform.position).magnitude))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
