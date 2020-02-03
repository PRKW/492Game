using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHealth;
    int enemydamage;
    float enemySpeed;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 5;
       // anim = GetComponent<Animator>();
       // anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int damage)
    {
        enemyHealth -= damage;
        Debug.Log("takedamage!");
    }
}
