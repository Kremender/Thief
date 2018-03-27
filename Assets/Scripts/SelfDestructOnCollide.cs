using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructOnCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "PlayerHull" || collision.collider.tag == "Background") // || collision.collider.tag == "Shield")
            Destroy(gameObject);
    }


}
