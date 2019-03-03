using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{

    [SerializeField] private Camera player1Camera, player2Camera;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

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

        #region Obstacle spawning for Player 1
        spawnHeight = Random.Range(-1f, 2f);
        spawnPos = player1Camera.ViewportToWorldPoint(new Vector3(1.1f, spawnHeight, -player1Camera.transform.position.z));

        if (obstacle.parent.name == "BlackHoles" || obstacle.parent.name == "Stations")
        {
            if (!Physics.CheckSphere(spawnPos, 30))
            {
                newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
            }
        }
        else if (obstacle.parent.name == "StarShips")
        {
            if (!Physics.CheckSphere(spawnPos, 30))
            {
                newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
            }
        }
        else
        {
            newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
        }
        #endregion

        #region Obstacle spawning for Player 2
        spawnHeight = Random.Range(-1f, 2f);
        spawnPos = player2Camera.ViewportToWorldPoint(new Vector3(1.1f, spawnHeight, -player1Camera.transform.position.z));

        if (obstacle.parent.name == "BlackHoles" || obstacle.parent.name == "Stations")
        {
            if (!Physics.CheckSphere(spawnPos, 30))
            {
                newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
            }
        }
        else if (obstacle.parent.name == "StarShips")
        {
            if (!Physics.CheckSphere(spawnPos, 30))
            {
                newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
            }
        }
        else
        {
            newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
        }
        #endregion

        float posX = newObstacle.transform.position.x;
        float posY = newObstacle.transform.position.y;
        newObstacle.transform.position = new Vector3(posX, posY, 0);

        yield return new WaitForSeconds(obstacle.cooldown);
        StartCoroutine(Spawn(obstacle));
    }
}
