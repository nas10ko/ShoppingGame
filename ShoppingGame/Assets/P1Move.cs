using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
    public float Speed;
    public Transform orientation; // Direction facing

    public float HorizontalIn; // left/right Input
    public float VertIn; // Forward/Backward input

    Vector3 moveDir;
    Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Player1_Inputs() {
        HorizontalIn = Input.GetAxisRaw("Horizontal");
        VertIn = Input.GetAxisRaw("Vertical");
    }

    private void Movement() { // Keyboard controls
        moveDir = orientation.forward * VertIn + orientation.right * HorizontalIn;
        rb.AddForce(moveDir.normalized * Speed * 10f, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        Player1_Inputs();
    }

    private void FixedUpdate() {
        Movement();
    }
}
