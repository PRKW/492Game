using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking;
   [SerializeField] Collider2D attackTrigger; ///use trigger/// 
    float attackTimer = 0;
    float attackCd = 0.3f;
    private void Awake()
    {
        attacking = false;
        attackTrigger.enabled = false; //disable attack collider 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)&& !attacking)
        {
            attacking = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
        }
        if(attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
