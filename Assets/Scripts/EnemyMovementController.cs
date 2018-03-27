using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour {

    public GameObject Player;
    //public GameObject ShieldHull;
    public GameObject Squirt;

    //public float followSharpness = 0.1f;
    //Vector3 FollowOffsetOnCircle;
    public float InitSquirtShootTime; //= 0.0f;
    public float NewFollowOffsetTime; //= 0.0f;
    public float NewFollowOffsetPeriod; // = 3f; //*seconds to re-calculate new position for thief
    Vector3 PlayerPositionWithOffset;

    //
    //private Rigidbody2D rb2d;
    private Animator animator;
    //
    int doBurstFwdHash;
    //int doBurstBwdHash;

    //
    Vector3 currentPosition;
    Vector3 previousPosition;

    //*
    //public Rigidbody2D squirt;

    //*
    private float currentAngle;
    private float targetAngle;

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    float GetAngleBetweenVectors(Vector3 target, Vector3 source)
    {
        Vector3 TargetToSourceNormal = (target - source).normalized;
        return Mathf.Atan2(TargetToSourceNormal.y, TargetToSourceNormal.x) * Mathf.Rad2Deg;
    }

    Vector3 TargetPositionWithOffset(Vector3 target)
    {
        //*vector on circlew
        //FollowOffsetOnCircle = Random.insideUnitCircle.normalized;
        //print(FollowOffsetOnCircle);
        //return target + FollowOffsetOnCircle;

        float radius = 1.5f;
        float angle = Mathf.Ceil(Random.value * 360);
        Vector3 position;
        position.x = target.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        position.y = target.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        //pos.z = target.z;
        position.z = 0;

        return position;

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Use this for initialization
    void Start () {

        //*
        //rb2d = GetComponent<Rigidbody2D>();

        //*
        PlayerPositionWithOffset = TargetPositionWithOffset(Player.transform.position);

        //float currentAngle = GetAngleBetweenVectors(GhostPositionWithOffset, transform.position);

        //*
        animator = GetComponent<Animator>();
        doBurstFwdHash = Animator.StringToHash("doBurstFwd");
        //doBurstBwdHash = Animator.StringToHash("doBurstBwd");

        //*initial positions conditions to track thief movement
        currentPosition = transform.position;
        previousPosition = transform.position;

        //*squirt shooting
        //InvokeRepeating("ShootSquirt", 3, 2f);
    }
	
	// Update is called once per frame
	void Update () {

        //*modify thief's offset every x seconds
        if (Time.time > NewFollowOffsetTime)
        {

            PlayerPositionWithOffset = TargetPositionWithOffset(Player.transform.position);

            targetAngle = GetAngleBetweenVectors(PlayerPositionWithOffset, transform.position);
            //print("Target" + targetAngle);
            
            //*increment time
            //NewFollowOffsetTime += NewFollowOffsetPeriod;
        }

        currentAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, 90f * Time.deltaTime);
        //currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, 90f * Time.deltaTime);
        //print("Current" + currentAngle);

        if (currentAngle != targetAngle)
        { 
            transform.position += (PlayerPositionWithOffset - transform.position) * Time.deltaTime;
            transform.position += Quaternion.Euler(0, 0, currentAngle) * Vector3.left * 0.3f * Time.deltaTime;
        }
        else
            transform.position += (PlayerPositionWithOffset - transform.position) * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, 0f, GetAngleBetweenVectors(Player.transform.position, transform.position) - 90);

        //*shooting
        if (Time.time > NewFollowOffsetTime)
        {
            if (Time.time > InitSquirtShootTime)
            { 
                ShootSquirt();
            }
            NewFollowOffsetTime += NewFollowOffsetPeriod;
        }

    }

    void LateUpdate()
    {

        //*track thief's movement to show engines burst animation
        currentPosition = transform.position;
        if (currentPosition != previousPosition) animator.SetTrigger(doBurstFwdHash); //*play engines burst forward animation
        previousPosition = currentPosition;

    }

    private void FixedUpdate()
    {
        //*for physiscscs!
    }

    void ShootSquirt()
    {
        //Rigidbody2D SquirtClone;
        GameObject SquirtClone;
        //Rigidbody2D SquirtCloneRb2d;

        //float SquirtCloneForce = 120f;
        float ThiefToGhostLerpDistancePct = 0.2f;

        //get intrapolated distance from thief to player
        Vector3 ThiefToGhostLerp = Vector3.Lerp(transform.position, Player.transform.position, ThiefToGhostLerpDistancePct / ((transform.position - Player.transform.position).magnitude));

        //print("PointToPlayer-> X, Y : " + ThiefToGhostLerp.x + "," + ThiefToGhostLerp.y);
        //print("Squirt Shot!");

        //*calculate squirt rotation to point to ghost
        Quaternion SquirtRotationInDegrees_z = Quaternion.Euler(0f, 0f, GetAngleBetweenVectors(Player.transform.position, transform.position) - 90);

        //*instantiate squirt in position and rotated
        SquirtClone = Instantiate(Squirt, ThiefToGhostLerp, SquirtRotationInDegrees_z) as GameObject;
        //SquirtCloneRb2d = Instantiate(squirt, ThiefToGhostLerp, SquirtRotationInDegrees_z) as Rigidbody2D;

        SquirtMovementHoming SquirtHomingScript = SquirtClone.GetComponent<SquirtMovementHoming>();
        SquirtHomingScript.Target = Player;


    }

}
