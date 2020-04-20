using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    int enemydamage;
    float enemySpeed;
    Animator anim;
    bool gettingHit;
    float stunTime;
    float stunTimer;
    // [SerializeField] bool isBoss;
    [SerializeField] GameObject bloodEffect;
    Rigidbody2D enemyRigid;
    // Start is called before the first frame update
    void Start()
    {
        //enemyHealth = 99;
        stunTime = 2f;
        stunTimer = stunTime ;
        gettingHit = false;
        enemyRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(FindObjectOfType<PlayerInfo>().playerDmg);
    }
    private void FixedUpdate()
    {
        stun();
    }
    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
    }
    private void OnTriggerEnter2D(Collider2D atkCol)
    {
        if (atkCol.gameObject.tag == "AttackTrigger")
        {
            FindObjectOfType<GameSession>().AddCombo(1);
            TakeDamage(FindObjectOfType<PlayerInfo>().playerDmg);
            Instantiate(bloodEffect , transform.position , Quaternion.identity);
            Knockback();
            gettingHit = true;
            if (enemyHealth <= 0)
            {
                EnemyDead();
            }
        }
    }

    void EnemyDead()
    {
        Destroy(this.gameObject);
        FindObjectOfType<GameSession>().AddScore(200);
    }

    void ReactToPlayerAttack()
    {

    }
    void Knockback()
    {
        enemyRigid.velocity = new Vector2(enemyRigid.velocity.x, 5f);
    }
    void stun()
    {
     if(gettingHit)
        {
            if(stunTimer > 0)
            {
                stunTimer -= Time.deltaTime;
                enemyRigid.velocity = new Vector2(0f, enemyRigid.velocity.y);
            }
            else
            {
                gettingHit = false;
                stunTimer = stunTime;
            }
        }
   
    }

    void Dropitem()
    {

    }
}
