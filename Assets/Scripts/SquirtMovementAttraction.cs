using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtMovementAttraction : MonoBehaviour
{

    public GameObject Target;  //*when prefab is linked this script targets prefab instead of game object

    public float PullForce;
    public float MinHomeDistance;
    public bool CanBeAttracted;
    public float MaxSpeed;

    Rigidbody2D Rb2d;

    private GameObject Player;

    private void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        CanBeAttracted = true;
        Player = GameObject.FindGameObjectWithTag("PlayerHull");  //*when prefab is linked this script targets prefab instead of game object
    }

    private void Update()
    {
        //*
    }

    private void FixedUpdate()
    {

        if (Vector3.Distance(Player.transform.position,transform.position) <= MinHomeDistance)
            CanBeAttracted = false;

        if (CanBeAttracted)
        {
            if (Vector3.Distance(Player.transform.position, transform.position) > MinHomeDistance)
            {
                Vector3 DirectonToPlayerNormalized = (Player.transform.position - transform.position).normalized;
                Rb2d.AddForce(DirectonToPlayerNormalized * PullForce * Time.deltaTime);
            }

            Rb2d.velocity = Vector2.ClampMagnitude(Rb2d.velocity, MaxSpeed);

        }

    }

}
