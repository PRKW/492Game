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
       // Debug.Log(PlayerInfo.attackType);
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
            anim.SetBool("Up", PlayerInfo.attackType.Contains("U"));
            anim.SetBool("Down", PlayerInfo.attackType.Contains("D"));
            anim.SetBool("Mid", PlayerInfo.attackType.Contains("M"));
           // anim.SetBool("Air", PlayerInfo.attackType.Contains("A"));
            anim.SetBool("NormalAttack", PlayerInfo.attackType.Contains("N"));
            anim.SetBool("SpecialAttack", PlayerInfo.attackType.Contains("S"));

        }
        else
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
            anim.SetBool("Mid", false);
           // anim.SetBool("Air", false);
            anim.SetBool("NormalAttack", false);
            anim.SetBool("SpecialAttack", false);
        }
        /// Damaged State ///
        anim.SetBool("Damaged",PlayerInfo.attacked);
    }
    void DashEffect()
    {

    }

    void dumpcode()
    {
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
}
