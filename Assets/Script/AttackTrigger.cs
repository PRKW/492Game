using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D atkCol)
    {
        if (atkCol.gameObject.tag == "Enemy")
        {
            Debug.Log("ATTACK!!!!");
        }
    }
}
