using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Crewmate_Script : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activeDistance = 50f;
    public float updateSecs = 0.5f;
    public float currentLoc = 0;
    public float targetLoc = 0;

    [Header("Physics")]
    public float speed = 3f;
    public float nextWaypoint = 0.05f;

    [Header("Custom Behavior")]
    public bool followEnabled = true;
    public bool directionChangeEnabled = true;

    private Path path;
    private int currentWaypoint = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, updateSecs);
    }

    private void FixedUpdate()
    {
              
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
        }
    }

    void UpdatePath()
    {
        if (TargetInDistance() && followEnabled && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }

    void PathFollow()
    {
        //make sure there is a path to follow
        
        if (path == null)
        {
            return;
        }

        //make sure we still have waypoints to follow

        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }

        //see if it's colliding with anything
        isGrounded = Physics2D.Raycast(transform.position, -Vector3.up, GetComponent<Collider2D>().bounds.extents.y);

         Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;


        //Debug.Log(direction);

        //Move the Target, stopping when it reaches 0.05f
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        

         



        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypoint)
        {
            currentWaypoint++;
        }

        //flipping sprite
        if (directionChangeEnabled)
        {
            if (rb.velocity.x > 0.05f)
            {
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            if (rb.velocity.x < -0.05f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }

    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activeDistance;
    }

    private void OnPathComplete(Path p)
    {
        
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

}
