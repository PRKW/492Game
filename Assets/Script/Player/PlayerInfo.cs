using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    float invincibleTime;
    [HideInInspector] public int playerDmg;
    [HideInInspector] public static string playerWeapon;
    public static string attackType;

    // Start is called before the first frame update
    private void Awake()
    {
        playerWeapon = "DuelKnife";
    }
    void Start()
    {
        playerDmg = 2;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerInfo();

       // Debug.Log(attackType);
    }
    void UpdatePlayerInfo()
    {
        Up();
        Down();
        UpdateWeaponInfo();
        UpdateDamageInfo();
        AttacktypeInfo();
    }
    public bool Up()
    {
        return (Input.GetKey(KeyCode.UpArrow));
    }

    public bool Down()
    {
        return (Input.GetKey(KeyCode.DownArrow));
    }

    public bool Mid()
    {
        if (!Up() && !Down()) return true;
        else return false;
    }
    void UpdateWeaponInfo()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerWeapon = "DuelKnife";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerWeapon = "Spear";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerWeapon = "GreatSword";
        }
    }
    void UpdateDamageInfo()
    {
        if (playerWeapon == "DuelKnife")
        {
            playerDmg = 1;
        }
        if (playerWeapon == "Spear")
        {
            playerDmg = 2;
        }
        if (playerWeapon == "GreatSword")
        {
            playerDmg = 3;
        }
    }

    void AttacktypeInfo() // determine attack type // 
    // 1st letter -> G = Greatsword , P = sPear , K = duelKnife /// 2nd letter -> M = Mid , U = UP , D = Down/// 3rd letter ->  N = Normal, S = Special /// 4th  letter A = Air , if none = Ground;
    {
        if (playerWeapon == "GreatSword")
        {
            if (PlayerAttack.normalAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "GUN";
                    else if (Down()) attackType = "GDN";
                    else if(Mid()) attackType = "GMN";
                }
                else
                {
                    if (Up()) attackType = "GUNA";
                    else if (Down()) attackType = "GDNA";
                    else if (Mid()) attackType = "GMNA";
                }
            }
            else if (PlayerAttack.specialAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "GUS";
                    else if (Down()) attackType = "GDS";
                    else if (Mid()) attackType = "GMS";
                }
                else
                {
                    if (Up()) attackType = "GUSA";
                    else if (Down()) attackType = "GDSA";
                    else if (Mid()) attackType = "GMSA";
                }
            }
            else attackType = null;
        }
        if (playerWeapon == "Spear")
        {
            if (PlayerAttack.normalAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "PUN";
                    else if (Down()) attackType = "PDN";
                    else if (Mid()) attackType = "PMN";
                }
                else
                {
                    if (Up()) attackType = "PUNA";
                    else if (Down()) attackType = "PDNA";
                    else if (Mid()) attackType = "PMNA";
                }
            }
            else if (PlayerAttack.specialAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "PUS";
                    else if (Down()) attackType = "PDS";
                    else if (Mid()) attackType = "PMS";
                }
                else
                {
                    if (Up()) attackType = "PUSA";
                    else if (Down()) attackType = "PDSA";
                    else if (Mid()) attackType = "PMSA";
                }
            }
            else attackType = null;
        }
        if (playerWeapon == "DuelKnife")
        {
            if (PlayerAttack.normalAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "KUN";
                    else if (Down()) attackType = "KDN";
                    else if (Mid()) attackType = "KMN";
                }
                else
                {
                    if (Up()) attackType = "KUNA";
                    else if (Down()) attackType = "KDNA";
                    else if (Mid()) attackType = "KMNA";
                }
            }
            else if (PlayerAttack.specialAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "KUS";
                    else if (Down()) attackType = "KDS";
                    else if (Mid()) attackType = "KMS";
                }
                else
                {
                    if (Up()) attackType = "KUSA";
                    else if (Down()) attackType = "KDSA";
                    else if (Mid()) attackType = "KMSA";
                }
            }
            else attackType = null;
        }
    }
}
