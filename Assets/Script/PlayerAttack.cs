using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask whatIsEnemy;
    [SerializeField] Transform attackPos;
    float attackTimer = 0;
    float attackCd = 0.3f;

    private void Awake()
    {
        attacking = false;
    }

    void Update()
    {

    }
}
