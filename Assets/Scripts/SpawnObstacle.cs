using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{

    [SerializeField] private Camera player1Camera, player2Camera;
    private Camera firstCamera;

    // the obstacle struct holds data to spawn each obstacle
    [System.Serializable]
    public struct ObstacleSpawn
    {
        public GameObject prefab;
        public float cooldown;
        public Transform parent;
    }

    [SerializeField] private ObstacleSpawn[] obstacles;
    private float spawnHeight;
    private Vector3 spawnPos;
    private GameObject newObstacle;


    void Start()
    {
        foreach (ObstacleSpawn obstacle in obstacles) {
            StartCoroutine(Spawn(obstacle));
        }
    }

    private IEnumerator Spawn(ObstacleSpawn obstacle)
    {
        spawnHeight = Random.Range(-2f, 3f);
        
        firstCamera = GetFirstCamera();
        spawnPos = firstCamera.ViewportToWorldPoint(new Vector3(1.1f, spawnHeight, -firstCamera.GetComponent<CameraMouvement>().offsetZ));

        if (Physics.CheckSphere(spawnPos, 30) && (obstacle.parent.name == "BlackHoles" || obstacle.parent.name == "Stations"))
        {
            StartCoroutine(Spawn(obstacle));
            yield return null;
        }
        else
        {
            newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);

            yield return new WaitForSeconds(obstacle.cooldown);
            StartCoroutine(Spawn(obstacle));
        }
    }

    private Camera GetFirstCamera()
    {
        if (player1Camera.transform.position.x > player2Camera.transform.position.x)
            return player1Camera;
        else
            return player2Camera;
    }
}
