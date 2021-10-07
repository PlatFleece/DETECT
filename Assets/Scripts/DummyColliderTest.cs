using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyColliderTest : MonoBehaviour
{
    public Collider2D[] colliders;
    public Collider2D[] hitcolliders;
    
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        colliders = gameObject.GetComponentsInChildren<Collider2D>();
        

        foreach (Collider2D c in colliders)
        {
            
        }
    }
}
