using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveV2 : MonoBehaviour
{
    bool playerIsInRadius;
    [SerializeField] float playerCheckRadius;
    [SerializeField] LayerMask whatIsPlayer;
    float walkSpeed = 200f;
    Transform playerTarget;
    float moveDirection;
    Rigidbody2D enemyRigid;

    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Mathf.Sign(playerTarget.transform.position.x - transform.position.x); //
        Debug.Log(moveDirection);
        if(playerIsInRadius)
        {
            if(PlayerIsOnRight())
            {
                enemyRigid.velocity = new Vector2(walkSpeed * Time.deltaTime, enemyRigid.velocity.y);
            }
            else enemyRigid.velocity = new Vector2(-walkSpeed * Time.deltaTime, enemyRigid.velocity.y);
        }
        else enemyRigid.velocity = new Vector2(0, enemyRigid.velocity.y);
    }

    bool PlayerIsOnRight()
    {
        return moveDirection > 0;
    }
    private void FixedUpdate()
    {
        playerIsInRadius = Physics2D.OverlapCircle(transform.position, playerCheckRadius, whatIsPlayer);
    }

    void OnDrawGizmosSelected() //draw circle base on this object transform.position and collider radius
    {
        Gizmos.color = Color.red; //Select wire color
        Gizmos.DrawWireSphere(transform.position, playerCheckRadius);
    }
}
