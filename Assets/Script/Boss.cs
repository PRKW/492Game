using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject bloodEffect;
    [SerializeField]int bossHealth;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = 2;
    }
    public void TakeDamage(int damage)
    {
        bossHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D atkCol)
    {
        if (atkCol.gameObject.tag == "AttackTrigger")
        {
            FindObjectOfType<GameSession>().AddCombo(1);
            TakeDamage(FindObjectOfType<PlayerInfo>().playerDmg);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (bossHealth <= 0)
        {
            GameSession.stageClear = true;
        }
    }
}
