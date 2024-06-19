using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    Animator playerAnimator;

    [SerializeField] float jumpForce = 10f;
    [SerializeField] float gravityModifier;
    
    bool isGrounded = true;
    public bool gameOver;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded) && (!gameOver)) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            playerAnimator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
        }
    }

}
