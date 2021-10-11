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

        if (collision.tag == "crew")
        {
            ElevatorCheck(crewmate);
        }
    }

    private bool ElevatorCheck(GameObject crewmate)
    {
        crewScript = crewmate.GetComponent<Crewmate_Script>();

        if (crewScript.elevatorUse)
        {
            StartCoroutine(EleWaiter(crewmate));
        }
        else
        {
            
        }

        return true;
    }

    IEnumerator EleWaiter(GameObject crewmate)
    {
        int elevFloor = crewScript.targetLoc;
        Transform crewPos = crewmate.transform;

        elevTarget = FindElevator(elevFloor);
        yield return new WaitForSeconds(5);
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
