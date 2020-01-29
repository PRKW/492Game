using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerMove playermove;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playermove = GetComponent<PlayerMove>();
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
        bool jump = Input.GetButtonDown("Jump");
        anim.SetBool("isJump", jump == true);

    }
}
