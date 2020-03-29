using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator anim;
    [SerializeField] GameObject dashEffect;
    float attackAnimResetTimer;

    // Start is called before the first frame update
    private void Awake()
    {
        attackAnimResetTimer = 0;
    }
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
        anim.SetBool("IsMove", h != 0);

        ///Jump Animation///
        anim.SetBool("IsGround", PlayerMove.isGrounded);

        ///Dash Animation///
        //anim.SetBool("isDash", PlayerMove.Dashing);

        ///Weapon State///
        if (PlayerInfo.playerWeapon == "DuelKnife")
        {
            anim.SetBool("UseDuelKnife", true);
            anim.SetBool("UseGreatSword", false);
            anim.SetBool("UseSpear", false);
        }
        if (PlayerInfo.playerWeapon == "Spear")
        {
            anim.SetBool("UseDuelKnife", false);
            anim.SetBool("UseGreatSword", false);
            anim.SetBool("UseSpear", true);
        }
        if (PlayerInfo.playerWeapon == "GreatSword")
        {
            anim.SetBool("UseDuelKnife", false);
            anim.SetBool("UseGreatSword", true);
            anim.SetBool("UseSpear", false);
        }

        ///Attack State///
        if (PlayerInfo.attackType != null)
        {
            if (PlayerInfo.attackType.Contains("U")) Debug.Log("Up");
            else if (PlayerInfo.attackType.Contains("D")) Debug.Log("Down");
            else if (PlayerInfo.attackType.Contains("M")) Debug.Log("Mid");

            if (PlayerInfo.attackType.Contains("A")) Debug.Log("Air");

            if (PlayerInfo.attackType.Contains("N")) Debug.Log("Normal");
            else if (PlayerInfo.attackType.Contains("S")) Debug.Log("Special");
        }

    }
    void DashEffect()
    {
        if (PlayerInfo.attackType.Contains("U")) Debug.Log("Up");
        else if (PlayerInfo.attackType.Contains("D")) Debug.Log("Down");
        else if (PlayerInfo.attackType.Contains("M")) Debug.Log("Mid");

        if (PlayerInfo.attackType.Contains("A")) Debug.Log("Air");

        if (PlayerInfo.attackType.Contains("N")) Debug.Log("Normal");
        else if (PlayerInfo.attackType.Contains("S")) Debug.Log("Special");
    }
}
