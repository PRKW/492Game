using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D enemyRigid;
    float walkSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFaceRight())
        {
            enemyRigid.velocity = new Vector2(walkSpeed*Time.deltaTime, enemyRigid.velocity.y);
        }
        else enemyRigid.velocity = new Vector2(-walkSpeed*Time.deltaTime, enemyRigid.velocity.y);
    }

    bool IsFaceRight() //if scale > 0 , enemy is facing right
    {
        return transform.localScale.x > 0 ;
    }
    private void OnTriggerExit2D(Collider2D collision) //flip when trigger collider stopped touching anything
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigid.velocity.x)), 1f);
    }
}
