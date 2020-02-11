using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] GameObject cameraObject;
    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        ShakeCamera();
    }

    public void ShakeCamera()
    {

    }
}
