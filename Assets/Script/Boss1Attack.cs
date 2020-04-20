using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Attack : MonoBehaviour
{
    [SerializeField] Transform attackPosition;
    [SerializeField] Transform attackPosition2;
    [SerializeField] GameObject attack;
    Animator anim;

    float ranX;
    float timer1 , timer2 ,attackTime1 , attackTime2;

    private void Awake()
    {
        timer1 = 0;
        timer2 = 0;
        attackTime1 = 1.22f;
        attackTime2 = 2.17f;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Boss.currentBossHealth <= 40)
        {
            attackTime1 = 0.61f;
            attackTime2 = 1.38f;
            anim.SetBool("Phase2", true);
        }
        Debug.Log(Boss.currentBossHealth);
        ranX = Random.Range(-5f, 5f);
        Vector3 Position1 = new Vector3(attackPosition.transform.position.x + ranX , attackPosition.transform.position.y);
        Vector3 Position2 = new Vector3(attackPosition2.transform.position.x + ranX, attackPosition2.transform.position.y);

        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        if(timer1 <= 0 )
        {
            timer1 = attackTime1;
            Instantiate(attack, Position1, Quaternion.identity);
        }
        if(timer2<=0)
        {
            timer2 = attackTime2;
            Instantiate(attack, Position2, Quaternion.identity);
        }

    }
}
