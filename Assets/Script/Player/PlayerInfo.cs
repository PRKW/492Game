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

    void AttacktypeInfo() // determine attack type // There are no duplicate character
    // 1st letter -> G = Greatsword , P = sPear , K = duelKnife /// 2nd letter -> M = Mid , U = UP , D = Down/// 3rd letter ->  N = Normal, S = Special /// 4th  letter A = Air , if none = Ground;
    //*2nd letter -> F = Forward ,use for dash attack //
    {
        if (playerWeapon == "GreatSword")
        {
            if (PlayerAttack.specialAttack || PlayerAttack.normalAttack )  // GreatSword has no normal attack so all normal become special
            {
                if (PlayerMove.isGrounded)
                {
                    if (Up()) attackType = "GMS"; //no up move so it become mid
                    else if (Down()) attackType = "GDS";// stop movement and will have bombing
                    else if (Mid()) attackType = "GMS"; //stop movement and push enemy back
                }
                else
                {
                    if (Up()) attackType = "GMSA"; // no up air move so it become mid
                    else if (Down()) attackType = "GDSA"; // *have movement downward 
                    else if (Mid()) attackType = "GMSA"; //nothing special
                }
            }
            else attackType = null;
        }
        if (playerWeapon == "Spear") // spear has no addition air attack
        {
            if (PlayerAttack.specialAttack || PlayerAttack.normalAttack)
            {
                    if (Up()) attackType = "PUS"; //stop movement and push enemy up+slightly forward
                    else if (Down() && PlayerMove.isGrounded) attackType = "PDS"; // stop movement and will have something bombing
                    else attackType = "PMN"; // Change special to normal because lazy to change anim , stop movement
            }
            else if (PlayerMove.dashing) attackType = "PMS"; //dash , forward dash movement
            else attackType = null;
        }
        if (playerWeapon == "DuelKnife")
        {
            if (PlayerAttack.specialAttack || PlayerAttack.normalAttack)
            {
                    if (PlayerMove.isGrounded)
                    {
                        if (Up()) attackType = "KUS"; //up movement
                        else if (Down()) attackType = "KDN"; // too lazy to change anim condition so S become N , stop movement
                        else if (Mid()) attackType = "KMS"; // stop movement
                    }
                    else
                    {
                        if (Up()) attackType = "KUSA"; // have aura attack
                        else if (Down()) attackType = "KDSA"; //have down-forward movement
                        else if (Mid()) attackType = "KMSA"; // have forward movement while on air
                    }
                }
            else attackType = null;
        }
    }
}
