﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject dashEffect;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
    }
    private void FixedUpdate()
    {
        ///Walk Animation///
        var h = Input.GetAxis("Horizontal");
        anim.SetBool("isWalk", h != 0);

        ///Jump Animation///
        anim.SetBool("isGround", PlayerMove.isGrounded);

        ///Dash Animation///
        //anim.SetBool("isDash", PlayerMove.Dashing);
        
        ///Weapon State///
        
    }
    void DashEffect()
    {

    }
}