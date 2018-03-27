using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsHullController : MonoBehaviour {

    //*outside visible objects
    public GameObject PickupsShell;

    //*internal objects
    private GameObject[] PickupsShellClones;
    

    // Use this for initialization
    void Start () {

        int spawnTimeInitSec = 3;
        int spawnTimeIntervalSec = 3;

        InvokeRepeating("SpawnPickupsShellClone", spawnTimeInitSec, spawnTimeIntervalSec);

        //*debug
        //SpawnPickupsShellClone();
        //SpawnPickupsShellClone();
        //SpawnPickupsShellClone();
        //SpawnPickupsShellClone();

    }

    private List<Vector3> SpawnSpotsInitialization()
    {
        //*list of spawn points X, Y
        List<Vector3> SpawnSpots = new List<Vector3>();

        //*initialize list by manual spawns points
        SpawnSpots.Add(new Vector3(10, 10));
        SpawnSpots.Add(new Vector3(10, -10));
        SpawnSpots.Add(new Vector3(-10, 10));
        SpawnSpots.Add(new Vector3(-10, -10));
        SpawnSpots.Add(new Vector3(20, 20));
        SpawnSpots.Add(new Vector3(20, -20));
        SpawnSpots.Add(new Vector3(-20, 20));
        SpawnSpots.Add(new Vector3(-20, -20));


        return SpawnSpots;

    }

    private Vector3 GetRandomValidSpawnSpot(List<Vector3> _SpawnSpots)
    {
        int RandomSpawnSpotElementIndex = Random.Range(0, _SpawnSpots.Count);
        return _SpawnSpots[RandomSpawnSpotElementIndex];
    }

    //*check existence of spawn on spawn spot
    

    private void SpawnPickupsShellClone()
    {
        //*initialize spawn spots array
        List<Vector3> SpawnSpots = SpawnSpotsInitialization();
        //*choose random element from array
        Vector3 SpawnSpot = GetRandomValidSpawnSpot(SpawnSpots);

        //*debug print
        Debug.Log("SpawnPoint [X,Y] : [" + SpawnSpot.x + "," + SpawnSpot.y + "]");

        //*check existing clones positions agains generater spawn spot for validity
        PickupsShellClones = GameObject.FindGameObjectsWithTag("PickupsShell");
        bool isValidSpawnSpot = true;

        foreach (GameObject PickupsShellClone in PickupsShellClones)
        {
            if (PickupsShellClone.transform.localPosition == SpawnSpot)
            {
                isValidSpawnSpot = false;
                break;
            }
        }

        if (isValidSpawnSpot)
        {
            GameObject PickupsShellClone;
            PickupsShellClone = Instantiate(PickupsShell, transform, false) as GameObject;
            PickupsShellClone.transform.localScale = new Vector3(1f, 1f, 0);
            PickupsShellClone.transform.localPosition = new Vector3(SpawnSpot.x, SpawnSpot.y, 0);
        }
        else
        {
            //*if generated spot is not valid, do nothing
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
