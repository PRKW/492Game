using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCurser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        DontDestroyOnLoad(this.gameObject);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
