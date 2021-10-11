using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheckScript : MonoBehaviour
{
    [Header("Float Stuff")]
    public int floorNum = 0;

    //list of possible floors
    GameObject FirstFloor; 
    GameObject SecondFloor; 
    GameObject ThirdFloor;

    //the current floor we're in
    GameObject currentFloor;
    int floorLvl;

    //name of our GameObject, for switch case of the floor we're in
    string myFloor;

    //Script List
    public Crewmate_Script crewScript;
    public Object_Script objScript;
    void Start()
    {
        //find the list of possible floors and also get the name of the current floor we're in
        FirstFloor = GameObject.Find("Floor1");
        SecondFloor = GameObject.Find("Floor2");
        ThirdFloor = GameObject.Find("Floor3");
        myFloor = name;
    }

    // Update is called once per frame
    void Update()
    {
        //get the floor
        currentFloor = GetFloorNumber(myFloor);
        //Debug.Log(currentFloor + "is in Floor " + floorLvl);
    }

    //here we find the floor we are in, by passing in the name of our GameObject, and checking to see which floor it's in
    private GameObject GetFloorNumber(string floorName)
    {
        GameObject floorNum;

        switch (floorName)
        {
            case "Floor1":
                floorNum = FirstFloor;
                floorLvl = 1;
                break;
            case "Floor2":
                floorNum = SecondFloor;
                floorLvl = 2;
                break;
            case "Floor3":
                floorNum = ThirdFloor;
                floorLvl = 3;
                break;
            default:
                floorNum = null;
                floorLvl = 0;
                break;
        }

        return floorNum;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject entity = collision.gameObject;
        //find out how many crew there is in the current floor, then assign their current floor
        if (collision.tag == "crew")
        {
            crewScript = entity.GetComponent<Crewmate_Script>();
            crewScript.currentLoc = floorLvl;
        }
        //find out how many objects there is in the current floor, then assign their current floor
        if (collision.tag == "object")
        {
            objScript = entity.GetComponent<Object_Script>();
            objScript.currentLoc = floorLvl;
        }
    }
}
