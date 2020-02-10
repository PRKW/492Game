using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    int enemydamage;
    float enemySpeed;
    Animator anim;
    bool getHit;
    int playerDmg;
    // Start is called before the first frame update
    void Start()
    {
        //enemyHealth = 99;
        playerDmg = FindObjectOfType<PlayerInfo>().playerDmg;
    }

    // Update is called once per frame
    void Update()
    {

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
            TakeDamage(playerDmg);

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

    void Dropitem()
    {

    }
}
