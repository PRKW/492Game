using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public static bool pAttacking; //player is attacking bool
    public static bool normalAttack;
    public static bool specialAttack;
    [SerializeField] Collider2D attackTrigger; ///use trigger/// 
    float attackTimer = 0;
    float attackCd = 0.3f;
    PlayerInfo playerInfo;
    [HideInInspector] public static bool attackTimerEqual;
    bool up;
    private void Awake()
    {
        attackTimerEqual = false;
        pAttacking = false;
        specialAttack = false;
        attackTrigger.enabled = false; //make sure that attack collider is disable before game start
        playerInfo = GetComponent<PlayerInfo>();
        up = playerInfo.Up();
    }

    void Update()
    {
        Attack();
    }

    void Attack() //get attack input and determind attack colloder and state
    {
        if (Input.GetKeyDown(KeyCode.Z) && !pAttacking) // when press z if not attacking do attack
        {
            pAttacking = true;
            normalAttack = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.X) && !pAttacking)
        {
            pAttacking = true;
            specialAttack = true;
            attackTimer = attackCd;
            attackTrigger.enabled = true;
        }

        if (pAttacking) //if attacking start attack timer to determine attack state
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

            }
            else
            {
                normalAttack = false;
                specialAttack = false;
                pAttacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}