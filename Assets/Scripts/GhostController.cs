using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour {


    public KeyCode pressUp;
    public KeyCode pressDown;
    public KeyCode pressLeft;
    public KeyCode pressRight;

    public float MoveForwardSpeed;
    public float MoveBackwardSpeed;
    public float RotateSpeed;

    //public bool isIdle;
    //public bool doBurst;

    private Rigidbody2D rb2d;
    private Animator animator;

    //public GameObject Player;
    //private Animator PlayerAnimator;

    int doBurstFwdHash;
    int doBurstBwdHash;

    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        doBurstFwdHash = Animator.StringToHash("doBurstFwd");
        doBurstBwdHash = Animator.StringToHash("doBurstBwd");

        //Animator PlayerAnimator = Player.GetComponent<Animator>();

        //isIdle = true;
        //doBurst = false;

    }

    // Update is called once per frame
    void Update()
    {

        //if (rb2d.IsSleeping())
        //    isIdle = true;
        //else
        //    isIdle = false;
    }

    private void FixedUpdate()
    {
        //*player movement - up / down
        //float moveVertical = Input.GetAxis("Vertical");

        //*player movement - rotate left / right
        //float moveHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(pressUp))
        { 
            //transform.position += transform.forward * Time.deltaTime * MoveSpeed;
            rb2d.AddForce(transform.up * MoveForwardSpeed);
            animator.SetTrigger(doBurstFwdHash);
        }

        if (Input.GetKey(pressDown))
        { 
            rb2d.AddForce(-transform.up * MoveBackwardSpeed);
            animator.SetTrigger(doBurstBwdHash);
        }

        if (Input.GetKey(pressLeft))
            transform.Rotate(Vector3.forward * RotateSpeed * Time.deltaTime);

        if (Input.GetKey(pressRight))
            transform.Rotate(Vector3.back * RotateSpeed * Time.deltaTime);

    }

}
