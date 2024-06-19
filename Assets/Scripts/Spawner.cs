using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] GameObject obstacle;
    Vector3 spawnPosition = new Vector3(25, 0, 0);
    [SerializeField] float spawnTime = 5f;
    PlayerController player;

    private void Start() {
        InvokeRepeating("SpawnObstacle", 0, spawnTime);
        player = FindAnyObjectByType<PlayerController>();
    }

    void SpawnObstacle() {
        if (!player.gameOver) {
            Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        }
    }

}
