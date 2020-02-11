using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMove3 : MonoBehaviour
{
    Path path;
    Seeker seeker;
    Rigidbody2D enemyRigid;
    [SerializeField] Transform target;
    int currentWayPoint = 0;
    bool reachedEndOfPoint = false;
    [SerializeField] float speed = 150f;
    public float nextWayPointDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        enemyRigid = GetComponent<Rigidbody2D>();
        path = GetComponent<Path>();
        seeker.StartPath(enemyRigid.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
