using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtMovementHoming : MonoBehaviour
{
    //*inputs
    public GameObject Target;
    public float ThisMoveSpeed;
    public float ThisToTargetMinDistance;

    Rigidbody2D Rb2d;

    //float ThisToTargetMaxAbsSize;
    //float ThisToTargetMinDistance;

    // Use this for initialization
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();

        //ThisToTargetMaxAbsSize = Mathf.Abs((Target.transform.position - transform.position).magnitude);
        //ThisToTargetMinDistance = ThisToGhostMinDistancePct * ThisToTargetMaxAbsSize;
        //ThisToTargetMinDistance = ThisToGhostMinDistance; // * ((Target.transform.position - transform.position).normalized.magnitude);

    }

    //float SquirtMoveSpeed = 2f;
    Vector3 DesiredPosition;
    Vector3 SmoothPosition;
    bool StopThisPositionUpdate = false;

    private void FixedUpdate()
    {
        float ThisToTargetAbsSize = Mathf.Abs((Target.transform.position - transform.position).magnitude);
        //*if distance of projectile is less than x% from Player
        if (!StopThisPositionUpdate)
        {
            if (ThisToTargetAbsSize < ThisToTargetMinDistance)
            {
                //Rb2d.AddForce(300 * (Target.transform.position - transform.position), ForceMode2D.Force); //*FORCE MODE -> FORCE
                Rb2d.AddForce(5 * (Target.transform.position - transform.position), ForceMode2D.Impulse); //*FORCE MODE -> IMPULS
                StopThisPositionUpdate = true;
            }
            else
            {
                DesiredPosition = Target.transform.position;
                //ThisMoveSpeed += 0.01f; //LINEAR INCREASE
                ThisMoveSpeed *= 1.01f; //QUADRATIC INCREASE
                SmoothPosition = Vector3.MoveTowards(transform.position, DesiredPosition, ThisMoveSpeed * Time.deltaTime);
                transform.position = SmoothPosition;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //*MJ's Camera Script
        //Vector3 desiredPosition = Target.transform.position;
        //Vector3 smoothenedPosition = Vector3.Lerp(desiredPosition, transform.position, SmoothSpeed * Time.deltaTime);
        //transform.position = smoothenedPosition;
        //**MJ's Camera Script

    }
}
