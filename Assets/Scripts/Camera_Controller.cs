using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    /*float xAxis;
    float yAxis;*/

    float camSpeed = 20f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        CameraMover();
    }

    private void CameraMover()
    {

            Vector3 pos = transform.position;
           
            if (Input.GetKey("w"))
            {
                pos.y += camSpeed * Time.deltaTime;
                
            }
            if (Input.GetKey("s"))
            {
                pos.y += -camSpeed * Time.deltaTime;

            }
            if (Input.GetKey("d"))
            {
                pos.x += camSpeed * Time.deltaTime;

            }
            if (Input.GetKey("a"))
            {
                pos.x += -camSpeed * Time.deltaTime;

            }

        transform.position = pos;
        
    }
}
