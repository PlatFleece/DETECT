using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_ActiveScript : MonoBehaviour
{
    GameObject childObject;

    // Start is called before the first frame update
    void Start()
    {
        childObject = GameObject.Find("Panel");
        childObject.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("x"))
        {
            Debug.Log("x is pressed");
            if (!childObject.activeSelf)
            {
                childObject.SetActive(true);
            }
            else if (childObject.activeSelf)
            {
                childObject.SetActive(false);
            }
        }
    }
}
