using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float playerSpeed=500f;
    float playerSpeedReserve;
    [SerializeField] float playerJumpPower=10f;
    [SerializeField] float playerDashPower = 5000f;
    Rigidbody2D PlayerRigid;
    [HideInInspector] public static bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkGroundRadius;
    public LayerMask whatIsGround;
    [SerializeField] int extraJump;
    int isJumped;
    bool faceRight = true;
    [SerializeField] float dashTime = 0.3f;
    float dTimer;
    [HideInInspector] public static bool dashing;
    bool done;
    float floatTime;
    float floatTimer;
    bool isFloating;


    private void Awake()
    {
        floatTime = 0.05f;
        isFloating = false;
        done = false;
        playerSpeedReserve = playerSpeed;
    }
    void Start()
    {
        floatTimer = floatTime;
        PlayerRigid = GetComponent<Rigidbody2D>();  // store rigidbody2D into PlayerRigid for convenience
        ResetJump();
        ResetDashTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 1)
        { 
            Move();
            Dash();
            Jump();
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkGroundRadius,whatIsGround);   // calculate collider using OverLabCircle(position,radius,layer)
        FaceCheck();
        AttackMovement();
        //Debug.Log(PlayerRigid.velocity.y);
    }


    void OnDrawGizmosSelected() //draw circle base on groundcheck.position and collider radius
    {
        Gizmos.color = Color.black; //Select wire color
        Gizmos.DrawWireSphere(groundCheck.position,checkGroundRadius);    //draw WireSphere base on child Position,radius that set in unity inspector
    }

    void FaceCheck()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon)
        {
            if (Mathf.Sign(Input.GetAxis("Horizontal")) > 0) faceRight = true;
            else if (Mathf.Sign(Input.GetAxis("Horizontal")) < 0) faceRight = false;
        }
    }

    void Move()
    {

        float h = Input.GetAxis("Horizontal");        //Recieve Horizontal Input

        if (!dashing)
        {//to prevent Jerky movement because Dash and Move use same rigidbody element
            PlayerRigid.velocity = new Vector2(h * playerSpeed * Time.deltaTime, PlayerRigid.velocity.y);    //use (h_input*speed) to change player rigidbody velocity , use exited y velocity 
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        ///*note* "Freeze Z rotation in Rigidbody2D to prevent falling over"(in unity inspector)///
        ///////////////////////////////////////////////////////////////////////////////////////////

        ///FlipSprite///
        if (Mathf.Abs(h) > Mathf.Epsilon)        //if player is moving horizontally 
                                                 //*note* Epsilon is smallest possible float near zero mostly use to avoid float rounding error (somehow)
        {
            transform.localScale = new Vector2(Mathf.Sign(h), 1f);  //flip sprite base on horizontal sign, keep y=1 as it is
        }
    }   //Move Function *use Dash*


    void Dash()
    {
        /// 0 is considered a positive number by Unity so we can't use Mathf.Sign to determined Dash direction.///
        /// add velocity alone will make player telepot , i use timer to prevent that.///
        if (Input.GetKeyDown(KeyCode.LeftShift)) dashing = true;

        if (dashing)
        {
            if(faceRight) PlayerRigid.velocity = new Vector2(playerDashPower * dTimer * Time.deltaTime,PlayerRigid.velocity.y+0.1f);
            else if(!faceRight) PlayerRigid.velocity = new Vector2(-playerDashPower * dTimer * Time.deltaTime, PlayerRigid.velocity.y + 0.1f);
            dTimer -= Time.deltaTime;
            if(dTimer <= 0 )
            {
                ResetDashTimer();
                dashing = false;
            }
        }

    }   //Dash Function

    void Jump()
    {
        bool jump = Input.GetButtonDown("Jump");    //Recieve Horizontal Input

        if (jump && isJumped > 0)   //Jump in condition if jump == true and Isjumped > 0
        {
            PlayerRigid.velocity = Vector2.up * playerJumpPower;// add velocity to Rigidbody *not sure why AddForce not work*
            isJumped--;
        }
        else if(isGrounded && isJumped == 0) //if isGround == true and isJump == 0 use ResetJump
        {
            ResetJump();
        }
    }   //Jump function

    void AttackMovement() //a lot of special attack make player move so i code here
    {
        if(PlayerAttack.pAttacking && isGrounded) // if player attack on ground
        {
            if (playerSpeed > 100) playerSpeed -= 50;
            else if (playerSpeed <= 100) playerSpeed = 100;
        }
        else if (PlayerAttack.pAttacking && !isGrounded) // if player attack on air
        {
            if (playerSpeed > 70) playerSpeed -= 50;
            else if (playerSpeed <= 70) playerSpeed = 70;
            if (!isFloating) isFloating = true;


        }
        else if (!PlayerAttack.pAttacking)
        {
            if (playerSpeed <= playerSpeedReserve)
            {
                if (PlayerInfo.playerWeapon == "spear") playerSpeed += 5;
                else playerSpeed += 15;
            }
            // playerSpeed = playerSpeedReserve;
        }

        if (isFloating)
        {
            if (floatTimer > 0 && PlayerRigid.velocity.y < 9)
            {
                PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, 4f);
                floatTimer -= Time.deltaTime;
            }
            else if(!PlayerAttack.pAttacking)
            {
                isFloating = false;
                floatTimer = floatTime;
            }
        }
        if (PlayerInfo.attackType == "GDSA") // down air attack for greatsword that make player move downward
        {
            if (!isGrounded)
            {
                PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, -10f);
            }
        }
        else if(PlayerInfo.attackType == "KUS") //up attack from ground make playerjump 
        {
            PlayerRigid.velocity = Vector2.up * playerJumpPower * 1.5f;
        }
        else if(PlayerInfo.attackType == "KDSA")
        {
            if (!isGrounded)
            {
                if (faceRight) PlayerRigid.velocity = new Vector2(10f, -10f);
                else PlayerRigid.velocity = new Vector2(-10f, -10f);
            }

        }
        else if (PlayerInfo.attackType == "KMSA")
        {
            if (PlayerRigid.velocity.y <= 5f)
            {
                if (faceRight) PlayerRigid.velocity = new Vector2(20f, PlayerRigid.velocity.y + 0.3f);
                else PlayerRigid.velocity = new Vector2(-20f, PlayerRigid.velocity.y + 0.3f);
            }
        }


        /// ground move that stop movement = GMS , GDS , PUS , PDS , PMN , KDN , KMS ///
        /// all move on air will make player floaty
        /// forward movement = PMS*already register as dash move  , GDSA down movement until player touch groud


    }

    void ResetJump() //+1 for base jump number then add extrajump number
    {
        isJumped = extraJump + 1;
    }
    void ResetDashTimer()
    {
        dTimer = dashTime;
    }
}
