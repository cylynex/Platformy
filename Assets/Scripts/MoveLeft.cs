using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    [SerializeField] public float speed;
    PlayerController player;

    private void Start() {
        player = FindObjectOfType<PlayerController>();
    }

    void Update() {
        if (player.gameOver == false) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -10) {
                Destroy(gameObject);
            }
        } 
    }

}
