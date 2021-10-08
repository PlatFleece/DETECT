using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyColliderTest : MonoBehaviour
{
    public Collider2D[] colliders;
    public Collider2D[] hitcolliders;

    Crewmate_Script crewScript;
    Object_Script objectScript;

    bool hasCollision = false;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        //int floorNum = LocateFloor();
        //Debug.Log("this is floor number" + floorNum);
        if (hasCollision)
        {
            //Debug.Log("There's someone inside of me");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.tag == "crew" || collision.tag == "object")
        {
            hasCollision = true;    
        }
    }

    /*int LocateFloor()
    {
        colliders = gameObject.GetComponentsInChildren<Collider2D>();
        int floorInt;
        int i = 0;
        int defaultValue = 0;

        foreach (Collider2D c in colliders)
        {

            Debug.Log(c);
            floorInt = i;
            return floorInt;
            i++;

        }
        
    }*/
}
