using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    // the obstacle struct holds data to spawn each obstacle
    [System.Serializable]
    public struct ObstacleSpawn
    {
        public GameObject prefab;
        public float speed;
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
        spawnHeight = Random.Range(-1f, 2f);
        spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, spawnHeight, 10f));

        newObstacle = Instantiate(obstacle.prefab, spawnPos, Quaternion.identity, obstacle.parent);

        yield return new WaitForSeconds(obstacle.cooldown);
        StartCoroutine(Spawn(obstacle));
    }
}
