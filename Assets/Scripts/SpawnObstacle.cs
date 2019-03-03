using Cinemachine;
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
    private float furthestX;
    private float playerY;


    private GameObject newObstacle;
    private int blackholesLayermask = 1 << 10;
    private int stationsLayermask = 1 << 11;
    private int spaceshipsLayermask = 1 << 12;


    void Start()
    {
        foreach (ObstacleSpawn obstacle in obstacles) {
            StartCoroutine(Spawn(obstacle));
        }
    }

    private IEnumerator Spawn(ObstacleSpawn obstacle)
    {
        while (true)
        {
            firstCamera = GetFirstCamera();

            #region Obstacle spawning for Player 1
            spawnHeight = Random.Range(-1f, 2f);
            // Get the x pos outside the viewport of the furthest player's camera
            furthestX = firstCamera.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x;
            // Get the y pos in front of the current player
            playerY = player1Camera.ViewportToWorldPoint(new Vector3(0f, spawnHeight, 0)).y;
            spawnPos = new Vector3(furthestX, playerY, 0);

            if (obstacle.parent.name == "BlackHoles")
            {
                if (Physics.OverlapSphere(spawnPos, 30, blackholesLayermask).Length == 0 && Physics.OverlapSphere(spawnPos, 5, stationsLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "Stations")
            {
                if (Physics.OverlapSphere(spawnPos, 30, stationsLayermask).Length == 0 && Physics.OverlapSphere(spawnPos, 5, blackholesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "SpaceShips")
            {
                if (Physics.OverlapSphere(spawnPos, 30, spaceshipsLayermask).Length == 0)
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

            // Get the x pos outside the viewport of the furthest player's camera
            furthestX = firstCamera.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x;
            // Get the y pos in front of the current player
            playerY = player1Camera.ViewportToWorldPoint(new Vector3(0f, spawnHeight, 0)).y;
            spawnPos = new Vector3(furthestX, playerY, 0);

            if (obstacle.parent.name == "BlackHoles")
            {
                if (Physics.OverlapSphere(spawnPos, 30, blackholesLayermask).Length == 0 
                    && Physics.OverlapSphere(spawnPos, 5, stationsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, spaceshipsLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "Stations")
            {
                if (Physics.OverlapSphere(spawnPos, 30, stationsLayermask).Length == 0 
                    && Physics.OverlapSphere(spawnPos, 5, blackholesLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, spaceshipsLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else if (obstacle.parent.name == "SpaceShips")
            {
                if (Physics.OverlapSphere(spawnPos, 10, spaceshipsLayermask).Length == 0 
                    && Physics.OverlapSphere(spawnPos, 5, stationsLayermask).Length == 0
                    && Physics.OverlapSphere(spawnPos, 5, blackholesLayermask).Length == 0)
                {
                    newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
                }
            }
            else
            {
                newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);
            }
            #endregion

            newObstacle.transform.position = new Vector3(newObstacle.transform.position.x, newObstacle.transform.position.y, 0);

            yield return new WaitForSeconds(obstacle.cooldown);
        }
    }

    private Camera GetFirstCamera()
    {
        if (player1Camera.transform.position.x > player2Camera.transform.position.y)
            return player1Camera;
        else
            return player2Camera;
    }
}
