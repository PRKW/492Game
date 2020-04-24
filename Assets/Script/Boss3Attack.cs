using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Attack : MonoBehaviour
{
    [SerializeField] Transform attackPosition;
    [SerializeField] GameObject attack;
    float randomNum;
    float spawnTime, spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 1f;
        spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        randomNum = Random.Range(6f,6f);
        spawnTimer -= Time.deltaTime;
        Vector3 Position = new Vector3(attackPosition.transform.position.x + randomNum, attackPosition.transform.position.y + randomNum);
        if (spawnTimer <=0)
        {
            Instantiate(attack, Position , Quaternion.identity);
            spawnTimer = spawnTime;
        }
    }
}
