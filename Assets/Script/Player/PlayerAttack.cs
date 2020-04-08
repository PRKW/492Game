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
        UpdateCollider();
        Attack();
        Debug.Log(attackTimer);
        
    }

    void UpdateCollider()
    {

        if (PlayerInfo.playerWeapon ==  "DuelKnife")
        {
            attackCd = 0.1f;
        }
        else if (PlayerInfo.playerWeapon == "GreatSword") attackCd = 0.5f;
        else
        {
            attackCd = 0.3f;
        }
    }

    void Attack() //get attack input and determind attack colloder and state
    {
        if (Input.GetKeyDown(KeyCode.Z) && !pAttacking) // when press z if not attacking do attack
        {

            attackTrigger.enabled = true;
            pAttacking = true;
            normalAttack = true;
            attackTimer = attackCd;

        }
        if (Input.GetKeyDown(KeyCode.X) && !pAttacking)
        {
            attackTrigger.enabled = true;
            pAttacking = true;
            specialAttack = true;
            attackTimer = attackCd;

        }
        if (pAttacking) //if attacking start attack timer to determine attack state
        {
            if (attackTimer > 0)
                {
                    attackTimer -= Time.deltaTime;

                }
            else
                {
                    attackTimer = attackCd;
                    normalAttack = false;
                    specialAttack = false;
                    pAttacking = false;
                    attackTrigger.enabled = false;
                }
        }
    }
}