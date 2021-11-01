using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_PanelPositioner : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 pos;
    
    void Start()
    {
        pos = GameObject.Find("ComputerTemp").transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Camera.main.WorldToScreenPoint(pos);
    }
}
