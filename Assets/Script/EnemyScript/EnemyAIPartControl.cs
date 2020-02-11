using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAIPartControl : MonoBehaviour
{

    AIPath aiPath;
    [SerializeField] float playerCheckRadius;
    [SerializeField] LayerMask whatIsPlayer;
    float aiSpeed;

    // Start is called before the first frame update
    void Start()
    {
        aiPath = GetComponent<AIPath>();
        aiSpeed = GetComponent<AIPath>().maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!playerIsInRadius())
        {
            aiPath.maxSpeed = Mathf.Clamp(aiPath.maxSpeed - (Time.deltaTime*3), 0, aiPath.maxSpeed);
        }
        else aiPath.maxSpeed = 3;
    }

    bool  playerIsInRadius()
    {
        return Physics2D.OverlapCircle(transform.position, playerCheckRadius, whatIsPlayer);
    }

    void OnDrawGizmosSelected() //draw circle base on this object transform.position and collider radius
    {
        Gizmos.color = Color.red; //Select wire color
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
