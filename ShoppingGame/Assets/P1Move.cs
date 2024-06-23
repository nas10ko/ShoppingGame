using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
    public float sensX;
    public float sensY;
    float xRotation;
    float yRotation;

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

    private void Movement() { // Keyboard controls
        moveDir = orientation.forward * VertIn + orientation.right * HorizontalIn;
        rb.AddForce(moveDir.normalized * Speed * 10f, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Axis3") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Axis6") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, 0f, 0f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        Player1_Inputs();
    }

    private void FixedUpdate() {
        Movement();
    }

    public void Player1_Inputs() {
        HorizontalIn = Input.GetAxisRaw("Horizontal");
        VertIn = Input.GetAxisRaw("Vertical");
    }
}
