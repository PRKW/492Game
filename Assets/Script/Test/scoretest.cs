using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoretest : MonoBehaviour
{
    public int score;
    int m_Score;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", score);
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        Debug.Log(PlayerPrefs.GetInt("Score"));
    }
}
