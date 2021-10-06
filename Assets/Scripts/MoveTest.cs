using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        Vector2 charPosition = new Vector2(transform.position.x, 0);
        Vector2 targetPosition = new Vector2(target.transform.position.x, 0);
        float stopRange = 0.05f;
        float distanceToTarget = Vector2.Distance(charPosition, targetPosition);

        if (distanceToTarget < stopRange)
        {
            //Debug.Log("Bar");
            return;
        }

        if (distanceToTarget > stopRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            //Debug.Log("Foo");
        }
    }
}
