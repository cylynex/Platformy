using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour {

    Vector3 startingPosition;
    float repeatWidth;
    [SerializeField] public float speed = 10f;
    PlayerController player;

    private void Start() {
        startingPosition = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        player = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if (!player.gameOver) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < startingPosition.x - repeatWidth) {
                transform.position = startingPosition;
            }
        }
    }

}
