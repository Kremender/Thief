using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject Target;

    public float SmoothSpeed;
    Rigidbody2D Rb2d;


    // Use this for initialization
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = Target.transform.position;
        Vector3 smoothenedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed * Time.deltaTime);

        transform.position = smoothenedPosition;

        //Rb2d.AddForce((Target.transform.position - transform.position).normalized*3f * Time.deltaTime); // Vector2.up); 
        //print(Target.transform.position.x);


    }
}
