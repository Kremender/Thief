using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    public KeyCode pressUp;
    public KeyCode pressDown;
    public KeyCode pressLeft;
    public KeyCode pressRight;

    public float MoveForwardSpeed;
    public float MoveBackwardSpeed;
    public float RotateSpeed;

    private Rigidbody2D Rb2d;
    private Animator animator;

    int doBurstFwdHash;
    int doBurstBwdHash;

    // Use this for initialization
    void Start()
    {

        Rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        doBurstFwdHash = Animator.StringToHash("doBurstFwd");
        doBurstBwdHash = Animator.StringToHash("doBurstBwd");

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {

        if (Input.GetKey(pressUp))
        {
            Rb2d.AddForce(transform.up * MoveForwardSpeed);
            animator.SetTrigger(doBurstFwdHash);
        }

        if (Input.GetKey(pressDown))
        {
            Rb2d.AddForce(-transform.up * MoveBackwardSpeed);
            animator.SetTrigger(doBurstBwdHash);
        }

        if (Input.GetKey(pressLeft))
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);

        if (Input.GetKey(pressRight))
            transform.Rotate(Vector3.back * RotateSpeed * Time.deltaTime);

    }

}
