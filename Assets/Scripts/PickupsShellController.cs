using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionProbability
{

    internal string Version;
    internal int ProbabilityPct;

    public VersionProbability(string Version, int ProbabilityPct)
    {
        this.Version = Version;
        this.ProbabilityPct = ProbabilityPct;
    }

}

public class PickupsShellController : MonoBehaviour {

    public GameObject PickupA;
    public GameObject PickupB;
    public GameObject PickupC;

    // Use this for initialization
    void Start () {

        //*
        List<VersionProbability> VersionProbabilityList = new List<VersionProbability>();

        //*
        VersionProbabilityList.Add(new VersionProbability("A", 20));
        VersionProbabilityList.Add(new VersionProbability("B", 30));
        VersionProbabilityList.Add(new VersionProbability("C", 50));

        List<string> VersionsArray = new List<string>();
        
        //*
        foreach (VersionProbability vp in VersionProbabilityList)
        {
            for (int i = 1; i <= vp.ProbabilityPct; i++)
            {
                VersionsArray.Add(vp.Version);
            }
        }

        //*returns a random integer number between min [inclusive] and max [exclusive] 
        int RandomSpawnVersionElementIndex = Random.Range(0, VersionsArray.Count);
        //*
        string RandomCloneVersion = VersionsArray[RandomSpawnVersionElementIndex];

        Debug.Log("RandomCloneVersion : " + RandomCloneVersion);

        GameObject PickupClone;

        //*
        switch (RandomCloneVersion)
        {
            case "A":
                PickupClone = Instantiate(PickupA, transform, false) as GameObject;
                //PickupClone.transform.position = new Vector3(0, 0, 0);
                PickupClone.transform.localScale = new Vector3(1f, 1f, 0);
                break;
            case "B":
                PickupClone = Instantiate(PickupB, transform, false) as GameObject;
                //PickupClone.transform.position = new Vector3(0, 0, 0);
                PickupClone.transform.localScale = new Vector3(1f, 1f, 0);
                break;
            case "C":
                PickupClone = Instantiate(PickupC, transform, false) as GameObject;
                //PickupClone.transform.position = new Vector3(0, 0, 0);
                PickupClone.transform.localScale = new Vector3(1f, 1f, 0);
                break;
            default:
                break;
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
