using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Script : MonoBehaviour
{
    [Header("Transport Stuff")]
    public Transform elevTarget;
    Crewmate_Script crewScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject crewmate = collision.gameObject;

        if (collision.tag == "crew" && collision.GetComponent<Crewmate_Script>().target == gameObject.transform)
        {
            ElevatorTransport(crewmate);
        }
    }

    private void ElevatorTransport(GameObject crewmate)
    {
        crewScript = crewmate.GetComponent<Crewmate_Script>();


            //crewScript.elevatorUse = false;
            //Debug.Log(name + "is going to teleport because " + crewScript.name + "'s ElevatorUse is " + crewScript.elevatorUse);
            StartCoroutine(EleWaiter(crewmate));


    }

    IEnumerator EleWaiter(GameObject crewmate)
    {
        yield return new WaitForSeconds(1);
        int elevFloor = crewScript.targetLoc;
        Transform crewPos = crewmate.transform;
        elevTarget = FindElevator(elevFloor);
        crewPos.position = elevTarget.transform.position;

    }

    private Transform FindElevator(int floorNumber)
    {
        Transform ElevatorPos;
        GameObject ElevObj;

        switch (floorNumber)
        {
            case 1:
                ElevObj = GameObject.Find("Elev1");
                ElevatorPos = ElevObj.transform;
                break;
            case 2:
                ElevObj = GameObject.Find("Elev2");
                ElevatorPos = ElevObj.transform;
                break;
            case 3:
                ElevObj = GameObject.Find("Elev3");
                ElevatorPos = ElevObj.transform;
                break;
            default:
                ElevatorPos = null;
                break;
        }

        return ElevatorPos;
    }
}
