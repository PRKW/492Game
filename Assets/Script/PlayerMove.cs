using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float playerSpeed=10f;
    [SerializeField] float playerJumpPower=10f;
    [SerializeField] float playerDashPower = 100f;
    Rigidbody2D PlayerRigid;
    [HideInInspector] public static bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkGroundRadius;
    public LayerMask whatIsGround;
    [SerializeField] int extraJump;
    int isJumped;
    bool faceRight = true;
    [SerializeField] float dashTime = 1f;
    float dTimer;
    [HideInInspector] public static bool Dashing;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();  // store rigidbody2D into PlayerRigid for convenience
        ResetJump();
        ResetDashTimer();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Dash();
        Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkGroundRadius,whatIsGround);   // calculate collider using OverLabCircle(position,radius,layer)
        FaceCheck();
       // Debug.Log(dTimer);
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

        if (!Dashing)
        {//to prevent Jerky movement because Dash and Move use same rigidbody element
            PlayerRigid.velocity = new Vector2(h * playerSpeed, PlayerRigid.velocity.y);    //use (h_input*speed) to change player rigidbody velocity , use exited y velocity 
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
        if (Input.GetKeyDown(KeyCode.LeftShift)) Dashing = true;

        if (Dashing)
        {
            if(faceRight) PlayerRigid.velocity = new Vector2(playerDashPower * dTimer,PlayerRigid.velocity.y+0.1f);
            else if(!faceRight) PlayerRigid.velocity = new Vector2(-playerDashPower * dTimer, PlayerRigid.velocity.y + 0.1f);
            dTimer -= Time.deltaTime;
            if(dTimer <= 0 )
            {
                ResetDashTimer();
                Dashing = false;
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

    void ResetJump() //set isJump = extraJump+1 when called
    {
        isJumped = extraJump + 1;
    }
    void ResetDashTimer()
    {
        dTimer = dashTime;
    }
}
