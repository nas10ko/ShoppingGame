using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    public float moveSpeed;
    public Transform orientation;

    public float GroundDrag;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update() {
        InputManager();
        SpeedControl();
        rb.drag = GroundDrag;
    }

    void FixedUpdate() {
        MovePlayer();
    }

    private void InputManager() {
        horizontalInput = Input.GetAxis("Horizontal2");
        verticalInput = Input.GetAxis("Vertical2");
    }

    private void MovePlayer() {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl() {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVelocity.magnitude > moveSpeed) {
            // if you are moving faster than your movement speed
            Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed; // calculate what the max velocity should be
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z); // apply to rigidbody
        }
    }
}
