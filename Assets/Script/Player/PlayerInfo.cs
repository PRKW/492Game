using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    float invincibleTime;
    [HideInInspector] public int playerDmg;
    [HideInInspector] public string playerWeapon;
    string attackType;

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
        Debug.Log(attackType);
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
    // 1st letter -> G = GreatSword , S = Spear , D = DuelKnife /// 2nd letter -> N = Normal, S = Special /// 3rd letter -> N = Neutral , U = UP , D = Down /// 4th  letter A = Air , if none = Ground;
    {
        if (playerWeapon == "GreatSword")
        {
            if (PlayerAttack.normalAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "GUN";
                    else if (Down()) attackType = "GDN";
                    else attackType = "GNN";
                }
                else
                {
                    if (Up()) attackType = "GUNA";
                    else if (Down()) attackType = "GDNA";
                    else attackType = "GNNA";
                }
            }
            else if (PlayerAttack.specialAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "GUS";
                    else if (Down()) attackType = "GDS";
                    else attackType = "GSN";
                }
                else
                {
                    if (Up()) attackType = "GUSA";
                    else if (Down()) attackType = "GDSA";
                    else attackType = "GSNA";
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
                    if (Up()) attackType = "SUN";
                    else if (Down()) attackType = "SDN";
                    else attackType = "SNN";
                }
                else
                {
                    if (Up()) attackType = "SUNA";
                    else if (Down()) attackType = "SDNA";
                    else attackType = "SNNA";
                }
            }
            else if (PlayerAttack.specialAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "SUS";
                    else if (Down()) attackType = "SDS";
                    else attackType = "SSN";
                }
                else
                {
                    if (Up()) attackType = "SUSA";
                    else if (Down()) attackType = "SDSA";
                    else attackType = "SSNA";
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
                    if (Up()) attackType = "DUN";
                    else if (Down()) attackType = "DDN";
                    else attackType = "DNN";
                }
                else
                {
                    if (Up()) attackType = "GUNA";
                    else if (Down()) attackType = "DDNA";
                    else attackType = "DNNA";
                }
            }
            else if (PlayerAttack.specialAttack)
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "DUS";
                    else if (Down()) attackType = "DDS";
                    else attackType = "DSN";
                }
                else
                {
                    if (Up()) attackType = "DUSA";
                    else if (Down()) attackType = "DDSA";
                    else attackType = "DSNA";
                }
            }
            else attackType = null;
        }
    }
}
