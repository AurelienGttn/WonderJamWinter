using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{

    private Camera player1Camera, player2Camera;
    private Transform player1, player2;
    private Camera firstCamera;

    // the obstacle struct holds data to spawn each obstacle
    [System.Serializable]
    public struct ObstacleSpawn
    {
        public GameObject prefab;
        public float cooldown;
        public Transform parent;
    }

    [SerializeField] private float spawnHeightRange = 20f;
    [SerializeField] private ObstacleSpawn[] obstacles;
    private float spawnHeight;
    private Vector3 spawnPos;
    private float furthestX;
    private float playerY;

    // Define layers for sphere check before spawning
    private GameObject newObstacle;
    private int movingObstaclesLayermask = 1 << 9;
    private int blackholesLayermask = 1 << 10;
    private int stationsLayermask = 1 << 11;
    private int spaceshipsLayermask = 1 << 12;
    private int bumpersLayermask = 1 << 15;


    void Start()
    {
        player1Camera = GameObject.Find("CameraJoueur1").GetComponent<Camera>();
        player2Camera = GameObject.Find("CameraJoueur2").GetComponent<Camera>();
        player1 = GameObject.Find("Player 1").transform;
        player2 = GameObject.Find("Player 2").transform;

        StartCoroutine(WaitBeforeSpawning());
    }

    private IEnumerator Spawn(ObstacleSpawn obstacle)
    {
        while (true)
        {
            firstCamera = GetFirstCamera();

            #region Obstacle spawning for Player 1
            spawnHeight = Random.Range(-spawnHeightRange, spawnHeightRange);
            // Get the x pos outside the viewport of the furthest player's camera
            furthestX = firstCamera.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x;
            // Get the y pos in front of the current player
            playerY = player1.position.y + spawnHeight;
            spawnPos = new Vector3(furthestX, playerY, 0);

            // For each static obstacle check if there is already the same obstacle in the area
            // Also check if there are other static obstacles near the spawn position
            if (obstacle.parent.name == "BlackHoles")
            {
                if (Physics.OverlapSphere(spawnPos, 30, blackholesLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 10, stationsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, spaceshipsLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "Stations")
            {
                if (player1.position.x < player2.position.x)
                {
                    if (Physics.OverlapSphere(spawnPos, 30, stationsLayermask).Length == 0
                        && Physics.OverlapSphere(spawnPos, 10, blackholesLayermask).Length == 0
                        && Physics.OverlapSphere(spawnPos, 5, spaceshipsLayermask).Length == 0
                        && Physics.OverlapSphere(spawnPos, 5, movingObstaclesLayermask).Length == 0)
                    {
                        newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                    }
                }
            }
            else if (obstacle.parent.name == "SpaceShips")
            {
                if (Physics.OverlapSphere(spawnPos, 10, spaceshipsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, blackholesLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, stationsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, movingObstaclesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "Bumpers")
            {
                if (Physics.OverlapSphere(spawnPos, 10, bumpersLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, movingObstaclesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else
            {
                if (Physics.OverlapSphere(spawnPos, 2, movingObstaclesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            #endregion

            #region Obstacle spawning for Player 2
            spawnHeight = Random.Range(-spawnHeightRange, spawnHeightRange);

            // Get the x pos outside the viewport of the furthest player's camera
            furthestX = firstCamera.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x;
            // Get the y pos in front of the current player
            playerY = player2.position.y + spawnHeight;
            spawnPos = new Vector3(furthestX, playerY, 0);

            // For each static obstacle check if there is already the same obstacle in the area
            // Also check if there are other static obstacles near the spawn position
            if (obstacle.parent.name == "BlackHoles")
            {
                if (Physics.OverlapSphere(spawnPos, 30, blackholesLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 10, stationsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, spaceshipsLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "Stations")
            {
                if (player2.position.x < player1.position.x)
                {
                    if (Physics.OverlapSphere(spawnPos, 30, stationsLayermask).Length == 0
                        && Physics.OverlapSphere(spawnPos, 10, blackholesLayermask).Length == 0
                        && Physics.OverlapSphere(spawnPos, 5, spaceshipsLayermask).Length == 0
                        && Physics.OverlapSphere(spawnPos, 5, movingObstaclesLayermask).Length == 0)
                    {
                        newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                    }
                }
            }
            else if (obstacle.parent.name == "SpaceShips")
            {
                if (Physics.OverlapSphere(spawnPos, 10, spaceshipsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, stationsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, blackholesLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, movingObstaclesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "Bumpers")
            {
                if (Physics.OverlapSphere(spawnPos, 10, bumpersLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, movingObstaclesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else
            {
                if (Physics.OverlapSphere(spawnPos, 2, movingObstaclesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            #endregion

            newObstacle.transform.position = new Vector3(newObstacle.transform.position.x, newObstacle.transform.position.y, 0);

            yield return new WaitForSeconds(obstacle.cooldown);
        }
    }

    private Camera GetFirstCamera()
    {
        if (player1Camera.transform.position.x > player2Camera.transform.position.x)
            return player1Camera;
        else
            return player2Camera;
    }

    private IEnumerator WaitBeforeSpawning()
    {
        yield return new WaitForSeconds(8f);

        foreach (ObstacleSpawn obstacle in obstacles)
        {
            StartCoroutine(Spawn(obstacle));
            yield return new WaitForSeconds(1f);
        }
    }
}
